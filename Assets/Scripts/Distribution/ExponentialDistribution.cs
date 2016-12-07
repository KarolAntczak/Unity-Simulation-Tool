using System;
using UnityEngine;

/// <summary>
/// Exponential distribution
/// </summary>
public class ExponentialDistribution : IDistribution
{
    private const float e = 2.71828f;

    public float Intensity = 1f;

    public float NextValue
    {
        get
        {
            float u = UnityEngine.Random.value;
            double r = Math.Log(1 - u, e) / (-Intensity);
            return (float) r;
        }
    }
}
