using UnityEngine;

[CreateAssetMenu(fileName = "EnemySettings", menuName = "Configurations/EnemySettings")]
public class EnemySettings : ScriptableObject
{
    public float walkSpeed = 2f; // Movement speed of enemy
    public float distance = 5f; // Distance variable
    public float jumpIntervalMin = 2f; // Minimum jump interval
    public float jumpIntervalMax = 5f; // Maximum jump interval
    public float sprintIntervalMin = 5f; // Minimum sprint interval
    public float sprintIntervalMax = 10f; // Maximum sprint interval
    public float sprintDuration = 2f; // Duration of sprint
    public float sprintMultiplier = 1.5f; // Speed multiplier during sprint
    public float jumpForce = 5f; // Jump force
}
