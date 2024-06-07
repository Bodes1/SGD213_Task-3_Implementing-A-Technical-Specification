using UnityEngine;

public class EnemyMovement : MonoBehaviour, IMoveable
{
    private Rigidbody2D rb;

    private void Awake()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
    }

    public void Move(float horizontalInput, float speed)
    {
        Vector2 movement = new Vector2(horizontalInput * speed, rb.velocity.y);
        rb.velocity = movement;
    }

    public void Jump(float jumpHeight)
    {
        if (IsGrounded()) // Use a method to check if the enemy is grounded
        {
            rb.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
        }
    }

    private bool IsGrounded()
    {
        // Implement ground check logic here
        return true; // Placeholder logic
    }
}
