using UnityEngine;

[CreateAssetMenu(fileName = "EnemySettings", menuName = "Configurations/EnemySettings")]
public class EnemySettings : ScriptableObject
{
    public readonly float walkSpeed = 2f; // Movement speed of enemy
    public readonly float distance = 5f; // Distance variable
    public readonly float jumpIntervalMin = 2f; // Minimum jump interval
    public readonly float jumpIntervalMax = 5f; // Maximum jump interval
    public readonly float sprintIntervalMin = 5f; // Minimum sprint interval
    public readonly float sprintIntervalMax = 10f; // Maximum sprint interval
    public readonly float sprintDuration = 2f; // Duration of sprint
    public readonly float sprintMultiplier = 1.5f; // Speed multiplier during sprint
    public readonly float jumpForce = 5f; // Jump force
}
