using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    // This is so you dont get a null reference exception
    [SerializeField]
    private GameObject getBarManager;

    // Variable for IHealth
    private IHealth updateHealth;

    private InvincibleStarPowerup updateStar;

    // Damage the player should take
    private float damageTaken;

    // Start is called before the first frame update
    void Start()
    {
        if (getBarManager != null)
        {
            updateHealth = getBarManager.GetComponent<IHealth>();
            updateStar = getBarManager.GetComponent<InvincibleStarPowerup>();
            if (updateHealth == null)
            {
                Debug.LogError("IHealth component is not found on the assigned GameObject.");
            }
            if (updateStar == null)
            {
                Debug.LogError("Star component is not found on the assigned GameObject.");
            }
        }

        damageTaken = 1f;
    }

    // Take damage when touching an enemy
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Hit");

            if (updateHealth != null)
            {
                updateHealth.Damage(damageTaken);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PickUp"))
        {
            Debug.Log("PickUp");

            if (updateStar != null)
            {
                updateStar.Invincible();
                Destroy(collision.gameObject);
            }
        }
    }
}