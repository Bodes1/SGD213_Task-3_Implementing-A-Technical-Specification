using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class controls the lifetime of a GameObject as a float value.
/// The particular use case for this is to kill powerup objects that the player
/// did not pick up or see.
/// </summary>
public class DieOverTime : MonoBehaviour
{
    [SerializeField]
    private float lifetime = 15f;
    
    void Update()
    {
        Destroy(gameObject, lifetime);
    }
}
