using UnityEngine;

/// <summary>
/// Handles the behavior of a health pickup, restoring health to the player upon collection.
/// </summary>
public class HealthPickup : MonoBehaviour
{
    [SerializeField] private float healthAmount = 20f; // Amount of health to restore

    /// <summary>
    /// Detects when the player collides with the pickup, restores health, and destroys the pickup.
    /// </summary>
    /// <param name="collision">The Collider2D data associated with this trigger event.</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            IHealth healthComponent = collision.GetComponent<IHealth>();
            if (healthComponent != null)
            {
                healthComponent.RestoreHealth(healthAmount);
                Destroy(gameObject); // Destroy the pickup after it has been collected
            }
        }
    }
}
