using System.Linq;
using UnityEngine;

public class ExtendUnitySelector : MonoBehaviour
{
    public ExtendUnity selectedConfig;

    private ExtendUnity[] allConfigs;

    void OnValidate()
    {
        // Auto-load all configs from the project
        allConfigs = Resources.LoadAll<ExtendUnity>("");
    }

    public void ApplyConfig()
    {
        if (selectedConfig != null)
        {
            Debug.Log($"Applied Config: {selectedConfig.configName}");
        }
        else
        {
            Debug.Log("No config selected!");
        }
    }
}
