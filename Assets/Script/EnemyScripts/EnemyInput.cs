using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInput : MonoBehaviour
{
    [SerializeField] private EnemySettings settings; // Reference to the Scriptable Object

    private IMoveable movement;  // Use the IMoveable interface

    private Vector3 startPosition; // Variable for starting position
    private float movingDirection; // Float variable to check direction of movement
    private int randomDirection; // Variable to hold a random number

    private float jumpTimer;
    private float sprintTimer;

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
        jumpTimer = Random.Range(settings.jumpIntervalMin, settings.jumpIntervalMax); // Randomize initial jump time
        sprintTimer = Random.Range(settings.sprintIntervalMin, settings.sprintIntervalMax); // Randomize initial sprint time

        // Initialize other properties
        randomDirection = Random.Range(0, 2);
        movingDirection = (randomDirection == 0) ? 1f : -1f;
        startPosition = transform.position;
    }

    private void Update()
    {
        // Handle movement
        movement.Move(movingDirection, settings.walkSpeed);

        // Handle turning
        if (movingDirection == 1f && transform.position.x >= startPosition.x + settings.distance)
        {
            movingDirection = -1f;
        }
        else if (movingDirection == -1f && transform.position.x <= startPosition.x - settings.distance)
        {
            movingDirection = 1f;
        }

        // Handle periodic jumping
        jumpTimer -= Time.deltaTime;
        if (jumpTimer <= 0)
        {
            movement.Jump(settings.jumpForce); // Use the jump force defined in the settings
            jumpTimer = Random.Range(settings.jumpIntervalMin, settings.jumpIntervalMax); // Reset the jump timer
        }

        // Handle periodic sprinting
        sprintTimer -= Time.deltaTime;
        if (sprintTimer <= 0)
        {
            StartCoroutine(SprintRoutine());
            sprintTimer = Random.Range(settings.sprintIntervalMin, settings.sprintIntervalMax); // Reset the sprint timer
        }
    }

    private IEnumerator SprintRoutine()
    {
        float originalSpeed = settings.walkSpeed;
        settings.walkSpeed *= settings.sprintMultiplier; // Increase speed for sprinting
        yield return new WaitForSeconds(settings.sprintDuration); // Sprint duration
        settings.walkSpeed = originalSpeed; // Reset to original speed
    }
}
