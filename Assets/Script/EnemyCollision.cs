using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField] private Vector2 boxSize; // Can change the size of the box
    [SerializeField] private float castDistance; // Can change the box position
    [SerializeField] private LayerMask playerLayer; // Can set what layer to detect, which should be set to default

    private void Update()
    {
        // If something on the Player layer touches the box the enemy will die
        if (IsStompedOn())
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Code for drawing the box and checking if the enemy is stomped on.
    /// </summary>
    private bool IsStompedOn()
    {
        return Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, playerLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position - transform.up * castDistance, boxSize);
    }
}
