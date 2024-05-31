using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private IHealth updateHealth;

    private float damageTaken = 25f;

    // Start is called before the first frame update
    void Start()
    {
        updateHealth = GetComponent<IHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (updateHealth != null)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                updateHealth.Damage(damageTaken);
            }
        }
    }
}
