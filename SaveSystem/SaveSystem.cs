using System.IO;
using UnityEngine;

namespace SaveSystem
{

    public class SaveSystem
    {
        /// <summary>
        /// Get the saved data as the given class type.
        /// </summary>
        /// <typeparam name="T">Class of data that will be loaded, must be System.Serializable</typeparam>
        /// <param name="gameData">Object that will save the saved data</param>
        /// <param name="nameFile">File of the name that will be loaded</param>
        /// <returns>String with the data as JSON. Use the prompt in the script to convert and load its data
        ///     "JsonUtility.FromJsonOverwrite(SaveSystem.ReadFile(this, "[FileName]"), this)" 
        /// </returns>
        public static string ReadFile<T>(T gameData, string nameFile)
        {
            string filePath = Application.persistentDataPath + "/Save/" + typeof(T) + "/" + nameFile + ".json";


            if (File.Exists(filePath))
            {
                return File.ReadAllText(filePath);
            }
            else
            {
                Debug.LogError("SaveSystem: Error reading the file " + nameFile + " (" + typeof(T) + ")");
            }

            return "";
        }

        /// <summary>
        /// Save a file into persistent data. The path is "/Save/File Type/nameFile.json"
        /// </summary>
        /// <typeparam name="T">Class type of data that will be saved, must be System.Serializable</typeparam>
        /// <param name="gameData">Object to be saved</param>
        /// <param name="nameFile">Name of how the file will be saved</param>
        public static void WriteFile<T>(T gameData, string nameFile)
        {
            if (!Directory.Exists(Application.persistentDataPath + "/Save/" + typeof(T)))
                Directory.CreateDirectory(Application.persistentDataPath + "/Save/" + typeof(T));

            string filePath = Application.persistentDataPath + "/Save/" + typeof(T) + "/" + nameFile + ".json";
            string jsonString = JsonUtility.ToJson(gameData);
            File.WriteAllText(filePath, jsonString);
        }
    }
}
