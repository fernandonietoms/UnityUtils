<div align="center">
  <img src="https://logos-download.com/wp-content/uploads/2019/11/Unity_Web_Player_Logo.png" alt="Unity" style="width:30%">
</div>

  <h1 align="center">
    Save System Script
  </h1>
  <p align="center">
    Unity 6
  </p>
  
<details open>
  <summary><h2>Description</h2></summary>
  <hr>
    <ul>
      <li>The purpose of this script is to have an public static method to Save & Load any type of script (MonoBehaviour instances included) on a Unity Project.</li>
      <li><b>Tested Version</b>: Unity 6</li>
    </ul>
</details>
<hr>
  
<details open>
  <summary><h2>Instructions</h2></summary>
  <hr>
    <ol>
      <li>Add the script to your project Asset folder.</li>
      <li>Add the attribute <b>[System.Serializable]</b> to your class that will be saved.</li>
      <li>Add the attribute <b>[SerializeField]</b> to the variables in your class that you want to be saved.</li>
      <li>To <b><i>Save</i></b> a script as a file, call the method 
        <pre>
          <br> SaveSystem.WriteFile&ltT&gt(T gameData, string nameFile)
        </pre>
        <ul>
          <li><b>T</b>: Class type of data that will be saved.</li>
          <li><b>gameData</b>: Object to be saved.</li>
          <li><b>nameFile</b>: Name of the file where the object will be saved.</li>
          <li>The <b>path</b> where it will be saved is: "[Application.persistentDataPath]/Save/[T]/[nameFile].json"</li>
        </ul>
      </li>
      <li> To <b><i>Load</i></b> the saved data in a existing Object with the script of the same class that was saved, call the method:
        <pre>
          <br> JsonUtility.FromJsonOverwrite(SaveSystem.ReadFile(this, "[FileName]"), this);
        </pre>
        <ul>
          <li>The method <b>SaveSystem.ReadFile()</b> returns a JSON string. Its components are:
            <ul>
              <li><b>T</b>: Class type of data that will be loaded.</li>
              <li><b>gameData</b>: Object used as a type reference to load the data.</li>
              <li><b>nameFile</b>: Name of the file that will be loaded.</li>
              <li>The <b>path</b> where it will be loaded from is: "[Application.persistentDataPath]/Save/[T]/[nameFile].json"</li>
            </ul>
          </li>
          <li><b>JsonUtility.FromJsonOverwrite()</b> second parameter is the reference of the script object that will be used to keep the data. Using "<b>this</b>" will save it in the caller object.</li>
        </ul>
      </li>
    </ol>
</details>
<hr>
