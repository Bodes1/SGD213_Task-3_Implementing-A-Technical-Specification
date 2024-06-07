using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMove 
{
    float speed { get; set; }
    void SetDirection(float x, float y);

}

