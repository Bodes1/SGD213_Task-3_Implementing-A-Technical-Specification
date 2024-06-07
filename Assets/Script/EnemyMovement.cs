using UnityEngine;

/// <summary>
/// Handles the movement and jumping behavior of enemy characters.
/// </summary>
public class EnemyMovement : MonoBehaviour, IMoveable
{
    private Rigidbody2D _rb;
    private GroundCheck _groundCheck;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _groundCheck = GetComponent<GroundCheck>();

        if (_rb == null)
        {
            Debug.LogError("Rigidbody2D component is missing from the GameObject");
        }

        if (_groundCheck == null)
        {
            Debug.LogError("GroundCheck component is missing from the GameObject");
        }
    }

    /// <summary>
    /// Moves the enemy horizontally based on input and speed.
    /// </summary>
    /// <param name="horizontalInput">The horizontal input value.</param>
    /// <param name="speed">The movement speed.</param>
    public void Move(float horizontalInput, float speed)
    {
        Vector2 movement = new Vector2(horizontalInput * speed, _rb.velocity.y);
        _rb.velocity = movement;
    }

    /// <summary>
    /// Makes the enemy jump if grounded.
    /// </summary>
    /// <param name="jumpHeight">The height of the jump.</param>
    public void Jump(float jumpHeight)
    {
        if (_groundCheck != null && _groundCheck.IsGrounded()) // Use the GroundCheck component to verify being grounded
        {
            _rb.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
        }
    }
}
