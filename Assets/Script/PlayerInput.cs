using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerMovement movement; // Reference to the PlayerMovement component
    private GroundCheck groundCheck; // Reference to the GroundCheck component

    [SerializeField] private float walkSpeed = 7.5f; // Player walk speed
    [SerializeField] private float runSpeedMultiplier = 2.5f; // Multiplier for running speed
    [SerializeField] private float jumpHeight = 16f; // Player jump height

    private float currentRunMultiplier = 1f; // Current running speed multiplier

    private void Awake()
    {
        movement = GetComponent<PlayerMovement>();
        groundCheck = GetComponent<GroundCheck>();
    }

    private void Update()
    {
        HandleMovementInput();
        HandleJumpInput();
    }

    private void HandleMovementInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float effectiveSpeed = walkSpeed * currentRunMultiplier;
        movement.Move(horizontalInput, effectiveSpeed);

        if (Input.GetButtonDown("Sprint"))
        {
            currentRunMultiplier = runSpeedMultiplier;
        }
        else if (Input.GetButtonUp("Sprint"))
        {
            currentRunMultiplier = 1f;
        }
    }

    private void HandleJumpInput()
    {
        if (Input.GetButtonDown("Jump") && groundCheck.IsGrounded())
        {
            movement.Jump(jumpHeight);
        }
    }
}
