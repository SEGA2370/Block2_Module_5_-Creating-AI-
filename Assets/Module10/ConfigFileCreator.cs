using System.IO;
using UnityEngine;

public class ConfigFileCreator : MonoBehaviour
{
    private string filePath;

    private void Start()
    {
        filePath = Path.Combine(Application.streamingAssetsPath, "configAsync.json");

        if (!File.Exists(filePath))
        {
            CreateConfigFile();
            Debug.Log("ConfigAsync file created successfully at: " + filePath);
        }
        else
        {
            Debug.Log("ConfigAsync file already exists.");
        }
    }

    private void CreateConfigFile()
    {
        string json = "{ \"playerSpeed\": 5.5, \"enemyCount\": 10, \"gameMode\": \"Hard\" }";
        Directory.CreateDirectory(Application.streamingAssetsPath); // Ensure the folder exists
        File.WriteAllText(filePath, json);
    }
}
