using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float speed = 10f; // Speed at which the projectile moves
    public float lifetime = 5f; // Lifetime of the projectile before it gets destroyed

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
