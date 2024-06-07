using UnityEngine;

/// <summary>
/// ScriptableObject to store player settings such as walk speed, run multiplier, and jump height.
/// </summary>
[CreateAssetMenu(fileName = "PlayerSettings", menuName = "Configurations/Player Settings")]
public class PlayerSettings : ScriptableObject
{
    /// <summary>
    /// The speed at which the player walks.
    /// </summary>
    public float walkSpeed = 5f;

    /// <summary>
    /// The multiplier applied to the walk speed when the player runs.
    /// </summary>
    public float runMultiplier = 2f;

    /// <summary>
    /// The height to which the player can jump.
    /// </summary>
    public float jumpHeight = 5f;
}
