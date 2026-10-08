using System.Collections.Generic; // For lists
using System.IO; // For file operations
using UnityEngine; // For Application.persistentDataPath
using Newtonsoft.Json;

namespace TiltanMobileSummer2026
{


   
    
    public static class JsonWithNewtonsoft
    {
        
        public static T ReadFromJsonFile<T>(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return default;
            }
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static void WriteToJsonFile<T>(string filePath, T objectToWrite)
        {
            string json = JsonConvert.SerializeObject(objectToWrite, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }
        
        // This function will save a list of GameData objects as a JSON file
        public static void SavePlayerDataList(List<GameData> dataList, string fileName)
        {
            // Convert the list of objects directly to JSON format using Newtonsoft.Json
            string json =
                JsonConvert.SerializeObject(dataList,
                    Formatting.Indented); // 'Indented' makes the output human-readable

            // Create a file path (this saves the file in the persistent data path of the game)
            string path = Path.Combine(Application.persistentDataPath, fileName + ".json");

            // Write the JSON data to a file
            File.WriteAllText(path, json);

            Debug.Log("List of data saved as JSON to: " + path); // For debugging purposes
        }

        // Generic function to read a list of any type from JSON
        public static List<T> ReadJsonList<T>(string filePath)
        {
            try
            {
                // Read the JSON file content
                string jsonContent = File.ReadAllText(filePath);

                // Deserialize the JSON to List<T>
                List<T> items = JsonConvert.DeserializeObject<List<T>>(jsonContent);

                Debug.Log($"Successfully read {items.Count} items from {filePath}");
                return items;
            }
            catch (System.Exception e)
            {
                Debug.LogError($"Error reading JSON file: {e.Message}");
                return new List<T>();
            }
        }
    }

}


