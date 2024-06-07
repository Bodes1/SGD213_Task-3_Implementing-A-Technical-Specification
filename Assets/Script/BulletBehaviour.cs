using UnityEngine;

/// <summary>
/// Handles the behavior of a bullet, including movement, collision detection, and destruction after a set lifetime.
/// </summary>
public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] private float speed = 10f; // Speed at which the projectile moves
    [SerializeField] private float lifetime = 5f; // Lifetime of the projectile before it gets destroyed

    private void Start()
    {
        // Destroy the projectile after its lifetime expires
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        // Move the projectile to the right
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    /// <summary>
    /// Handles collision with an enemy, destroying both the bullet and the enemy upon impact.
    /// </summary>
    /// <param name="collision">The Collider2D data associated with this trigger event.</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            // Destroy the enemy and the projectile upon collision
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
