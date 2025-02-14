using UnityEngine;

[CreateAssetMenu(fileName = "NewExtendUnity", menuName = "Configs/Extend Unity Config")]
public class ExtendUnity : ScriptableObject
{
    public string configName;
    public float playerHealth;
    public float playerSpeed;
}