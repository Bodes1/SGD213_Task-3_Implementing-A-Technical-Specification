using System.Collections;
using UnityEngine;

/// <summary>
/// Handles the input and movement logic for enemy characters, including walking, jumping, and sprinting.
/// </summary>
public class EnemyInput : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 2f; // Movement speed of enemy
    [SerializeField] private float distance = 5f; // Distance variable
    [SerializeField] private float jumpIntervalMin = 2f; // Minimum jump interval
    [SerializeField] private float jumpIntervalMax = 5f; // Maximum jump interval
    [SerializeField] private float sprintIntervalMin = 5f; // Minimum sprint interval
    [SerializeField] private float sprintIntervalMax = 10f; // Maximum sprint interval
    [SerializeField] private float sprintDuration = 2f; // Duration of sprint
    [SerializeField] private float sprintMultiplier = 1.5f; // Speed multiplier during sprint
    [SerializeField] private float jumpForce = 5f; // Jump force

    private IMoveable _movement; // Use the IMoveable interface

    private Vector3 _startPosition; // Variable for starting position
    private float _movingDirection; // Float variable to check direction of movement
    private int _randomDirection; // Variable to hold a random number

    private float _jumpTimer;
    private float _sprintTimer;

    private void Awake()
    {
        _movement = GetComponent<IMoveable>(); // Ensure the component implements IMoveable
        if (_movement == null)
        {
            Debug.LogError("IMoveable component is missing from the GameObject");
        }
    }

    private void Start()
    {
        // Initialize timers
        _jumpTimer = Random.Range(jumpIntervalMin, jumpIntervalMax); // Randomize initial jump time
        _sprintTimer = Random.Range(sprintIntervalMin, sprintIntervalMax); // Randomize initial sprint time

        // Initialize other properties
        _randomDirection = Random.Range(0, 2);
        _movingDirection = (_randomDirection == 0) ? 1f : -1f;
        _startPosition = transform.position;
    }

    private void Update()
    {
        // Handle movement
        _movement.Move(_movingDirection, walkSpeed);

        // Handle turning
        if (_movingDirection == 1f && transform.position.x >= _startPosition.x + distance)
        {
            _movingDirection = -1f;
        }
        else if (_movingDirection == -1f && transform.position.x <= _startPosition.x - distance)
        {
            _movingDirection = 1f;
        }

        // Handle periodic jumping
        _jumpTimer -= Time.deltaTime;
        if (_jumpTimer <= 0)
        {
            _movement.Jump(jumpForce); // Use the jump force defined in the settings
            _jumpTimer = Random.Range(jumpIntervalMin, jumpIntervalMax); // Reset the jump timer
        }

        // Handle periodic sprinting
        _sprintTimer -= Time.deltaTime;
        if (_sprintTimer <= 0)
        {
            StartCoroutine(SprintRoutine());
            _sprintTimer = Random.Range(sprintIntervalMin, sprintIntervalMax); // Reset the sprint timer
        }
    }

    /// <summary>
    /// Coroutine to handle the sprinting behavior for a specified duration.
    /// </summary>
    /// <returns>IEnumerator for coroutine.</returns>
    private IEnumerator SprintRoutine()
    {
        float originalSpeed = walkSpeed;
        walkSpeed *= sprintMultiplier; // Increase speed for sprinting
        yield return new WaitForSeconds(sprintDuration); // Sprint duration
        walkSpeed = originalSpeed; // Reset to original speed
    }
}
