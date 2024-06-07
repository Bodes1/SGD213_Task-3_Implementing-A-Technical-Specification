using UnityEngine;

/// <summary>
/// Handles ground checking for the entity, determining if it is on the ground using a box cast.
/// </summary>
public class GroundCheck : MonoBehaviour
{
    [SerializeField] private Vector2 boxSize; // Set this in the inspector
    [SerializeField] private float castDistance; // How far to cast the box
    [SerializeField] private LayerMask groundLayer; // Layer to check for ground

    /// <summary>
    /// Checks if the entity is on the ground.
    /// </summary>
    /// <returns>True if the entity is on the ground, false otherwise.</returns>
    public bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, boxSize, 0f, Vector2.down, castDistance, groundLayer);
        return hit.collider != null;
    }

    /// <summary>
    /// Optionally visualizes the check area in the editor.
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position + Vector3.down * castDistance, boxSize);
    }
}
