using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSettings", menuName = "Game Settings/Player Settings")]
public class PlayerSettings : ScriptableObject
{
    public float walkSpeed = 5f;
    public float runMultiplier = 2f;
    public float jumpHeight = 5f;
}
