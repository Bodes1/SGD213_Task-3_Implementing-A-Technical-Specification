using UnityEngine;

/// <summary>
/// Handles player input for movement, jumping, and shooting.
/// </summary>
public class PlayerInput : MonoBehaviour
{
    [SerializeField] private PlayerSettings settings; // Reference to the Scriptable Object

    private PlayerMovement _movement;
    private GroundCheck _groundCheck;
    private WeaponBase _weapon;
    private float _currentRunMultiplier = 1f; // Current running speed multiplier

    /// <summary>
    /// Gets or sets the weapon the player is using.
    /// </summary>
    public WeaponBase Weapon
    {
        get => _weapon;
        set => _weapon = value;
    }

    private void Awake()
    {
        _movement = GetComponent<PlayerMovement>();
        _groundCheck = GetComponent<GroundCheck>();
        _weapon = GetComponent<WeaponBase>();
    }

    private void Update()
    {
        HandleMovementInput();
        HandleJumpInput();
        HandleShootingInput();
    }

    /// <summary>
    /// Handles player movement input.
    /// </summary>
    private void HandleMovementInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float effectiveSpeed = settings.walkSpeed * _currentRunMultiplier; // Use the speed from settings
        _movement.Move(horizontalInput, effectiveSpeed);

        if (Input.GetButtonDown("Sprint"))
        {
            _currentRunMultiplier = settings.runMultiplier; // Use the run multiplier from settings
        }
        else if (Input.GetButtonUp("Sprint"))
        {
            _currentRunMultiplier = 1f;
        }
    }

    /// <summary>
    /// Handles player jump input.
    /// </summary>
    private void HandleJumpInput()
    {
        if (Input.GetButtonDown("Jump") && _groundCheck.IsGrounded())
        {
            _movement.Jump(settings.jumpHeight); // Use the jump height from settings
        }
    }

    /// <summary>
    /// Handles player shooting input.
    /// </summary>
    private void HandleShootingInput()
    {
        if (Input.GetButton("Fire1") && _weapon != null)
        {
            _weapon.Shoot();
        }
    }
}
