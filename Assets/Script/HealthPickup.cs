using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] private float healthAmount = 20f; // Amount of health to restore

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
