using UnityEngine;

/// <summary>
/// Handles the movement of the player character.
/// </summary>
public class PlayerMovement : MonoBehaviour, IMoveable
{
    [SerializeField] private Rigidbody2D rb;
    private GroundCheck _groundCheck; // Reference to the GroundCheck component

    private void Awake()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody2D>(); // Assign Rigidbody2D if not assigned in the Inspector
        _groundCheck = GetComponent<GroundCheck>(); // Ensure the GroundCheck script is attached to the same GameObject
    }

    public void Move(float horizontalInput, float speed)
    {
        Vector2 movement = new Vector2(horizontalInput * speed, rb.velocity.y);
        rb.velocity = movement;
    }

    public void Jump(float jumpHeight)
    {
        if (_groundCheck.IsGrounded()) // Direct call to groundCheck's IsGrounded
        {
            rb.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
        }
    }
}
