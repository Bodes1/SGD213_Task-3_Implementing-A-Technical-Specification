using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    // Making the "move" variable 
    private Movement move;

    // Player speed
    private float speed = 1000f;


    // Start is called before the first frame update
    void Start()
    {
        // Getting the "move" component
        move = GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get input
        float HorizontalInput = Input.GetAxis("Horizontal");

        // Turn input into direction
        Vector2 direction = new Vector2 (HorizontalInput, 0);

        if (HorizontalInput != 0.0f)
        {
            if (move != null)
            {
                // Call the movement script
                move.ObjectMovement(direction, speed);
            }
        }
    }
}
