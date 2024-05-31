using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    // This is so you dont get a null reference exception
    [SerializeField]
    private GameObject getHealthManager;

    // Variable for IHealth
    private IHealth updateHealth;

    // Damage the player should take
    private float damageTaken;

    // Start is called before the first frame update
    void Start()
    {
        if (getHealthManager != null)
        {
            updateHealth = getHealthManager.GetComponent<IHealth>();
            if (updateHealth == null)
            {
                Debug.LogError("IHealth component is not found on the assigned GameObject.");
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
}