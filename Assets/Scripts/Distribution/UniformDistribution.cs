using UnityEngine;

/// <summary>
/// Uniform distribution
/// </summary>
public class UniformDistribution: IDistribution
{
    public float Min=0, Max=1;
    
    public float NextValue
    {
        get
        {
            return Random.Range(Min, Max);
        }
    }
}