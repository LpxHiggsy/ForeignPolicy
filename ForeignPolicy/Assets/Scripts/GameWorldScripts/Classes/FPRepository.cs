using System;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
namespace Assets.Scripts.GameWorldScripts.Classes
{
    public class FPRepository
    {

        public static string LoadJSONProfile(string filename, string location, bool initialLoad = false)
        {
            string fileStringResult = "";
            
            if (initialLoad)    //If on Startup
            {
                 fileStringResult = LoadFile("NationInit.json", "");     //Load the file into string

                 if (FileExist(Path.Combine(Application.streamingAssetsPath, Path.Combine(location, filename))))       //Check if profile exist
                 {
                     fileStringResult = LoadFile(filename, location);        //Load old profile to string
                 }
                 else
                 {
                     NewFile(Path.Combine(Application.streamingAssetsPath, Path.Combine(location,filename)), fileStringResult);  //Create New profile
                 }
                
            }
            else
            {
                string filePath = Path.Combine(Application.streamingAssetsPath, @"Profiles\" + filename);

                if (File.Exists(filePath))
                {
                    fileStringResult = LoadFile(filePath, location);
                }
                else
                {
                    Debug.LogWarning(string.Format("{0} does not exist!", filePath));
                }
            }
            
            return fileStringResult;
        }

        public static string LoadFile(string fileName, string location)
        {
            string fileContents = "";
            string filePath = Path.Combine(Application.streamingAssetsPath, Path.Combine(location, fileName));
            
            if (Application.platform == RuntimePlatform.Android)    //If application is running on android 
            {
                WWW reader = new WWW(filePath);     //Create web reader with path
                while (!reader.isDone) { }          //Read data from web path

                string persistantDataPath = Path.Combine(Application.persistentDataPath , fileName);    //Create a new path using persistant data
                System.IO.File.WriteAllBytes(persistantDataPath, reader.bytes);     //Create new file android readable file at persistant data path
                filePath = persistantDataPath;      //Set root path as persistant data path
            }

            if (File.Exists(filePath))  //Check file exist
            {
                fileContents = File.ReadAllText(filePath);      //Load contents
            }
            else
            {
                Debug.LogWarning(string.Format("{0} does not exist!", filePath));
            }

            return fileContents;
        }

        private static bool FileExist(string filePath)
        {
            bool exist = false;

            if (Application.platform == RuntimePlatform.Android)    //If application is running on android 
            {
                WWW reader = new WWW(filePath); //Set root path as persistant data path
                while (!reader.isDone) { }
                
                if(!String.IsNullOrEmpty(reader.text))
                {
                    exist = true;
                }
            }
            else
            {
                exist = File.Exists(filePath);
            }

            return exist;
        }

        private static void NewFile(string fileName, string data)
        {
            //File.Create(fileName, data.Length);
            File.WriteAllText(fileName, data);
        }

        public static void SaveProfile(string filename, CoreDataModel coreDataModel)
        {
            string jsonData = JsonUtility.ToJson(coreDataModel);

            File.WriteAllText(Path.Combine(Application.streamingAssetsPath, @"Profiles\" + filename), jsonData);
        }
    }
}