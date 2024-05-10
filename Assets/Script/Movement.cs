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

    // Object Movement
    public void ObjectMovement(Vector2 direction, float speed)
    {
        Vector2 Movement = direction * speed * Time.deltaTime;
        rb.AddForce(Movement);
    }
}
