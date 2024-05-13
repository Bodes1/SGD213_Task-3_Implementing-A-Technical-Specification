using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Store a public reference to the Player game object, so we can refer to it's Transform
    [SerializeField]
    private GameObject player;

    // Store a Vector3 offset from the player (a distance to place the camera from the player at all times)
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        // Create an offset by subtracting the Camera's position from the player's position
        offset = transform.position - player.transform.position;
    }

    // After the standard 'Update()' loop runs, and just before each frame is rendered
    void LateUpdate()
    {
        // Set the camera postition at the end of the frame to follow player
        transform.position = player.transform.position + offset;
    }
}
