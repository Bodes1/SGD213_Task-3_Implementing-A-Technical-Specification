using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    // Making the "move" variable 
    private Movement movement;

    private float horizontalInput;

    // Player walk speed and run speed multipler
    private float walkSpeed = 10f;
    private float runSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        // Getting the "move" component
        movement = GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get input/direction
        horizontalInput = Input.GetAxis("Horizontal");     

        // Give the 'Movement' script the direction and speed
        movement.ObjectMovement(horizontalInput, walkSpeed, runSpeed);

        // If shift is press, itll multiple the player movement, making it sprint
        if (Input.GetButtonDown("Sprint")) 
        {
            runSpeed = 2f;
            Debug.Log("Sprinting");
        }
        else if (Input.GetButtonUp("Sprint"))
        {
            runSpeed = 1f;
            Debug.Log("Walking");
        }
    }
}
