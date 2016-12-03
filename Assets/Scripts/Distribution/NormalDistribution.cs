using System;
using UnityEngine;

/// <summary>
/// Normal distribution
/// </summary>
public class NormalDistribution : IDistribution
{
    public float Mean = 0, Deviation = 1;

    public float NextValue
    {
        get
        {

            float u1 = UnityEngine.Random.value;
            float u2 = UnityEngine.Random.value;
            float randStdNormal = (float) (Math.Sqrt(-2.0 * Math.Log(u1)) *
                         Math.Sin(2.0 * Math.PI * u2)); 
            return Mean + Deviation * randStdNormal; 
        }
    }
}