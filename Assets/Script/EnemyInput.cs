using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInput : MonoBehaviour
{
    private IMoveable movement;  // Use the IMoveable interface

    [SerializeField] private float enemyWalkSpeed = 2f; // Movement speed of enemy
    [SerializeField] private float distance = 5f; // Distance variable

    private Vector3 startPosition; // Variable for starting position
    private float movingDirection; // Float variable to check direction of movement
    private int randomDirection; // Variable to hold a random number

    private float jumpTimer;
    private float sprintTimer;

    [SerializeField] private float jumpIntervalMin = 2f;
    [SerializeField] private float jumpIntervalMax = 5f;
    [SerializeField] private float sprintIntervalMin = 5f;
    [SerializeField] private float sprintIntervalMax = 10f;
    [SerializeField] private float sprintDuration = 2f;
    [SerializeField] private float sprintMultiplier = 1.5f;

    private void Awake()
    {
        movement = GetComponent<IMoveable>(); // Ensure the component implements IMoveable
        if (movement == null)
        {
            Debug.LogError("IMoveable component is missing from the GameObject");
        }
    }

    private void Start()
    {
        // Initialize timers
        jumpTimer = Random.Range(jumpIntervalMin, jumpIntervalMax); // Randomize initial jump time
        sprintTimer = Random.Range(sprintIntervalMin, sprintIntervalMax); // Randomize initial sprint time

        // Initialize other properties
        randomDirection = Random.Range(0, 2);
        movingDirection = (randomDirection == 0) ? 1f : -1f;
        startPosition = transform.position;
    }

    private void Update()
    {
        // Handle movement
        movement.Move(movingDirection, enemyWalkSpeed);

        // Handle turning
        if (movingDirection == 1f && transform.position.x >= startPosition.x + distance)
        {
            movingDirection = -1f;
        }
        else if (movingDirection == -1f && transform.position.x <= startPosition.x - distance)
        {
            movingDirection = 1f;
        }

        // Handle periodic jumping
        jumpTimer -= Time.deltaTime;
        if (jumpTimer <= 0)
        {
            movement.Jump(((EnemyMovement)movement).jumpForce); // Use the jump force defined in the movement script
            jumpTimer = Random.Range(jumpIntervalMin, jumpIntervalMax); // Reset the jump timer
        }

        // Handle periodic sprinting
        sprintTimer -= Time.deltaTime;
        if (sprintTimer <= 0)
        {
            StartCoroutine(SprintRoutine());
            sprintTimer = Random.Range(sprintIntervalMin, sprintIntervalMax); // Reset the sprint timer
        }
    }

    private IEnumerator SprintRoutine()
    {
        float originalSpeed = enemyWalkSpeed;
        enemyWalkSpeed *= sprintMultiplier; // Increase speed for sprinting
        yield return new WaitForSeconds(sprintDuration); // Sprint duration
        enemyWalkSpeed = originalSpeed; // Reset to original speed
    }
}
