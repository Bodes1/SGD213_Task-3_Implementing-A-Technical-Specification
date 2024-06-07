using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public PlayerSettings settings; // Reference to the Scriptable Object

    private PlayerMovement movement;
    private GroundCheck groundCheck;

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
        float effectiveSpeed = settings.walkSpeed * currentRunMultiplier; // Use the speed from settings
        movement.Move(horizontalInput, effectiveSpeed);

        if (Input.GetButtonDown("Sprint"))
        {
            currentRunMultiplier = settings.runMultiplier; // Use the run multiplier from settings
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
            movement.Jump(settings.jumpHeight); // Use the jump height from settings
        }
    }
}
