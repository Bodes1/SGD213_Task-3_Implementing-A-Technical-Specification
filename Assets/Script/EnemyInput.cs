using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInput : MonoBehaviour
{
    // Make move varibale
    private Movement movement;

    // Movement speed of enemy
    [SerializeField]
    private float enemyWalkSpeed;

    // Distance varible
    [SerializeField]
    private float distance;

    // Varible for starting position
    private Vector3 startPosition;

    // bool varible to check direction of movement
    private float movingRight;

    // Varible to hold a number
    private int randomDirection;

    // Start is called before the first frame update
    void Start()
    {
        // Enemey will have a 50/50 chance to either go left or right first
        randomDirection = Random.Range(0, 2);
        if (randomDirection == 0 )
        {
            // Goes to the right
            movingRight = 1f;
        }
        else
        {
            // Goes to the left
            movingRight = -1f;
        }

        // Getting the "move" component
        movement = GetComponent<Movement>();

        // Get initial spawn position
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Moves the enemy
        movement.ObjectMovement(movingRight, enemyWalkSpeed, 1);

        // When the enemy moves a certain distance away from there start position they will turn around
        if (movingRight == 1f && transform.position.x >= startPosition.x + distance)
        {
            movingRight = -1f;
        }

        if (movingRight == -1f && transform.position.x <= startPosition.x - distance)
        {
            movingRight = 1f;
        }
    }
}
