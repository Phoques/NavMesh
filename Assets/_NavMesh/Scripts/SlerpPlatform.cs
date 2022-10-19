using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// dervied child class 
public class SlerpPlatform : MovingPlatform   // This means I am inheriting the values from the MovingPlatform script.
{
    
    protected override Vector3 NextMove(float t)
    {

        return Vector3.Slerp(_startPosition, _endPosition, t);

    }




}
