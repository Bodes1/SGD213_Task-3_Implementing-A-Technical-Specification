using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    // Making the "move" variable 
    private Movement movement;

    private float horizontalInput;

    // Player walk speed and run speed multipler
    private float walkSpeed = 7.5f;
    private float runSpeed = 1f;

    // Player jump height
    private float jumpHeight = 16f;


    // Can change the size of the box, which is used for detecting the ground
    [SerializeField]
    private Vector2 boxSize;

    // Can change the box position
    [SerializeField]
    private float castDistance;

    // Can set what layer to detect, which should be set to ground
    [SerializeField]
    private LayerMask groundLayer;

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
            runSpeed = 2.5f;
            Debug.Log("Sprinting");
        }
        else if (Input.GetButtonUp("Sprint"))
        {
            runSpeed = 1f;
            Debug.Log("Walking");
        }

        // If space is pressed and standing on floor, will jump
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            movement.ObjectJump(jumpHeight);
        }
    }

    private bool IsGrounded()
    {
        if(Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer))
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
        Gizmos.DrawWireCube(transform.position-transform.up * castDistance, boxSize);
    }



    // Detects if player is on "Floor" or not using the floor tag, This is purly just for me to know if the player is touching the ground
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Jumping");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Touching Ground");
        }
    }
}
