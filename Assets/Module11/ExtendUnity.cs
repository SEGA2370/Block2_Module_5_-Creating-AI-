using UnityEngine;

[CreateAssetMenu(fileName = "NewExtendUnity", menuName = "Configs/Extend Unity Config")]
public class ExtendUnity : ScriptableObject
{
    public string configName;
    public int maxPlayers;
    public float gameSpeed;
}