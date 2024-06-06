using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
  /// <summary>
  /// Turns off the Sprite Renderer for the object at runtime. This object
  /// serves as a waypoint for patrolling enemies and does not need to be visible to
  /// the player.
  /// </summary>  
    void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
    }

}
