using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject player; // Reference to the Player game object

    private Vector3 _offset; // Offset from the player

    private void Start()
    {
        // Create an offset by subtracting the Camera's position from the player's position
        _offset = transform.position - player.transform.position;
    }

    private void LateUpdate()
    {
        // Set the camera position at the end of the frame to follow the player
        transform.position = player.transform.position + _offset;
    }
}
