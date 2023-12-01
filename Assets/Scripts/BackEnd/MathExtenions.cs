using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MathExtenions
{
    public static float InvertOne(float value)
    {
        
        value = Mathf.Abs(value - 1);

        return value;
        
    }

    public static float InvertABS(float value)
    {
        value = (0 - value);

        return value;
    }

    public static float TempSkyFunc(float value)
    {
         if(value == 0.5)
        {
            return value /1.1f;
        }

        
        return 1 - value;
    }

    public static float Wave(float x, float t)
    {
        return Mathf.Sin(Mathf.PI * (x + t));
    }
}
