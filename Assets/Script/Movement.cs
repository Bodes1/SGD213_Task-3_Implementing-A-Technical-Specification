using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Any asset with this script will have a "rigidbody2D"
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Object Movement, if sprinting adds to the walk speed 
    public void ObjectMovement(float horizontalInput, float walkSpeed, float runSpeed)
    {
        Vector2 movement = new Vector2(horizontalInput * walkSpeed * runSpeed, rb.velocity.y);
        rb.velocity = movement;
    }

    // Object jump
    public void ObjectJump()
    {
        
    }
}
