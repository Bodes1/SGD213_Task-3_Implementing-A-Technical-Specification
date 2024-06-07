using UnityEngine;

/// <summary>
/// Handles player collision with enemies and pickups, and manages player state changes such as invincibility and health.
/// </summary>
public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private GameObject getBarManager;

    private PlayerHealth _updateHealth;
    private InvincibleStarPowerup _updateStar;

    private float _damageTaken;
    private bool _cantDie;

    private void Start()
    {
        if (getBarManager != null)
        {
            _updateHealth = getBarManager.GetComponent<PlayerHealth>();
            _updateStar = getBarManager.GetComponent<InvincibleStarPowerup>();
            if (_updateHealth == null)
            {
                Debug.LogError("PlayerHealth component is not found on the assigned GameObject.");
            }
            if (_updateStar == null)
            {
                Debug.LogError("InvincibleStarPowerup component is not found on the assigned GameObject.");
            }
        }

        _damageTaken = 1f;
    }

    /// <summary>
    /// Handles collision with enemies, dealing damage or destroying the enemy based on player state.
    /// </summary>
    /// <param name="collision">The collision data associated with this collision.</param>
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (_cantDie)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Destroy(collision.gameObject);
            }
        }
        else
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Debug.Log("Hit");

                if (_updateHealth != null)
                {
                    _updateHealth.TakeDamage(_damageTaken);
                }
            }
        }
    }

    /// <summary>
    /// Handles trigger events with pickups, applying effects such as health restoration, invincibility, or ammo addition.
    /// </summary>
    /// <param name="other">The Collider2D data associated with this trigger event.</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger Entered: " + other.gameObject.name);

        PickupIdentifier identifier = other.GetComponent<PickupIdentifier>();
        if (identifier != null)
        {
            switch (identifier.pickupType)
            {
                case PickupType.Health:
                    Debug.Log("HealthPickup Triggered");
                    if (_updateHealth != null)
                    {
                        _updateHealth.RestoreHealth(20f); // Use a value from the pickup if needed
                        Destroy(other.gameObject);
                    }
                    break;

                case PickupType.Invincible:
                    Debug.Log("InvinciblePickup Triggered");
                    if (_updateStar != null)
                    {
                        _updateStar.Invincible();
                        Destroy(other.gameObject);
                    }
                    break;

                case PickupType.Ammo:
                    Debug.Log("AmmoPickup Triggered");
                    WeaponBase weapon = GetComponentInChildren<WeaponBase>();
                    if (weapon != null)
                    {
                        weapon.AddAmmo(5); // Add 5 ammo
                        Destroy(other.gameObject);
                    }
                    break;
            }
        }
    }

    /// <summary>
    /// Empowers the player, making them invincible.
    /// </summary>
    public void Empowered()
    {
        _cantDie = true;
    }

    /// <summary>
    /// Depowers the player, removing their invincibility.
    /// </summary>
    public void Depowered()
    {
        _cantDie = false;
    }
}
