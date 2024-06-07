using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveable 
{
    void Move(float horizontalInput, float speed);
    void Jump(float jumpHeight);
}

