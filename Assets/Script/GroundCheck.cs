using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private Vector2 boxSize; // Set this in the inspector
    [SerializeField] private float castDistance; // How far to cast the box
    [SerializeField] private LayerMask groundLayer; // Layer to check for ground

    // Function to check if the entity is on the ground
    public bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, boxSize, 0f, Vector2.down, castDistance, groundLayer);
        return hit.collider != null;
    }

    // Optionally visualize the check area in the editor
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position + Vector3.down * castDistance, boxSize);
    }
}
