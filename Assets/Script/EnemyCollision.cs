using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    // Can change the size of the box
    [SerializeField]
    private Vector2 boxSize;

    // Can change the box position
    [SerializeField]
    private float castDistance;

    // Can set what layer to detect, which should be set to default
    [SerializeField]
    private LayerMask playerLayer;

    // Update is called once per frame
    void Update()
    {
        // If something on the Player layer touches the box the enemy will die
        if (IsStompedOn())
        {
            Destroy(gameObject);
        }
    }

    // Code for drawing the box
    private bool IsStompedOn()
    {
        if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, playerLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position - transform.up * castDistance, boxSize);
    }
}
