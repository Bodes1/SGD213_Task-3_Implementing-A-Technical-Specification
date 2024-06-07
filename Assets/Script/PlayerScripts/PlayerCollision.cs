using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private GameObject getBarManager;

    private PlayerHealth updateHealth;
    private InvincibleStarPowerup updateStar;

    private float damageTaken;
    private bool cantDie = false;

    void Start()
    {
        if (getBarManager != null)
        {
            updateHealth = getBarManager.GetComponent<PlayerHealth>();
            updateStar = getBarManager.GetComponent<InvincibleStarPowerup>();
            if (updateHealth == null)
            {
                Debug.LogError("PlayerHealth component is not found on the assigned GameObject.");
            }
            if (updateStar == null)
            {
                Debug.LogError("InvincibleStarPowerup component is not found on the assigned GameObject.");
            }
        }

        damageTaken = 1f;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (cantDie)
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

                if (updateHealth != null)
                {
                    updateHealth.TakeDamage(damageTaken);
                }
            }
        }
    }

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
                    if (updateHealth != null)
                    {
                        updateHealth.RestoreHealth(20f); // Use a value from the pickup if needed
                        Destroy(other.gameObject);
                    }
                    break;

                case PickupType.Invincible:
                    Debug.Log("InvinciblePickup Triggered");
                    if (updateStar != null)
                    {
                        updateStar.Invincible();
                        Destroy(other.gameObject);
                    }
                    break;
            }
        }
    }

    public void Empowered()
    {
        cantDie = true;
    }

    public void Depowered()
    {
        cantDie = false;
    }
}
