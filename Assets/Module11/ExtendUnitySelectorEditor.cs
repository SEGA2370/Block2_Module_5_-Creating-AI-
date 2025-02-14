using UnityEngine;
using UnityEditor;
using System.Linq;

[CustomEditor(typeof(ExtendUnitySelector))]
public class ExtendUnitySelectorEditor : Editor
{
    private string[] configNames;
    private int selectedIndex = 0;
    private ExtendUnity[] configs;

    private void OnEnable()
    {
        // Load all ExtendUnity configs
        configs = Resources.LoadAll<ExtendUnity>("");
        configNames = configs.Select(c => c.name).ToArray();
    }

    public override void OnInspectorGUI()
    {
        ExtendUnitySelector selector = (ExtendUnitySelector)target;

        if (configs.Length == 0)
        {
            EditorGUILayout.HelpBox("No ExtendUnity assets found in Resources.", MessageType.Warning);
            return;
        }

        selectedIndex = Mathf.Max(0, System.Array.IndexOf(configs, selector.selectedConfig));

        // Show dropdown
        selectedIndex = EditorGUILayout.Popup("Select Config", selectedIndex, configNames);
        selector.selectedConfig = configs[selectedIndex];

        if (selector.selectedConfig != null)
        {
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Config Details", EditorStyles.boldLabel);
            EditorGUILayout.LabelField("Name:", selector.selectedConfig.configName);
            EditorGUILayout.FloatField("Player Health:", selector.selectedConfig.playerHealth);
            EditorGUILayout.FloatField("Player Speed:", selector.selectedConfig.playerSpeed);
        }

        if (GUILayout.Button("Apply Config"))
        {
            selector.ApplyConfig();
        }

        EditorUtility.SetDirty(target);
    }
}
