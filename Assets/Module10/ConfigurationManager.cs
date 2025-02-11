using System.IO;
using System.Threading.Tasks;
using UnityEngine;

public class ConfigurationManager : MonoBehaviour
{
    public static ConfigurationManager Instance { get; private set; }
    public GameConfigJson ConfigAsync { get; private set; }

    public delegate void ConfigLoaded();
    public static event ConfigLoaded OnConfigLoaded;

    private string filePath;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            filePath = Path.Combine(Application.streamingAssetsPath, "configAsync.json");
            LoadConfigAsync();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private async void LoadConfigAsync()
    {
        string json = await ReadFileAsync(filePath);
        if (!string.IsNullOrEmpty(json))
        {
            ConfigAsync = JsonUtility.FromJson<GameConfigJson>(json);
            Debug.Log("Configuration Loaded Successfully!");

            // Notify other scripts that config is ready
            OnConfigLoaded?.Invoke();
        }
        else
        {
            Debug.LogError("Failed to load configuration file!");
        }
    }

    private async Task<string> ReadFileAsync(string path)
    {
        if (!File.Exists(path))
        {
            Debug.LogError("ConfigAsync file not found!");
            return null;
        }

        return await Task.Run(() => File.ReadAllText(path));
    }
}
