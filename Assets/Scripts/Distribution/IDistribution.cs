
/// <summary>
/// Probability distribution
/// </summary>
public interface IDistribution  {

    /// <summary>
    /// Return next random value with given distribution
    /// </summary>
    float NextValue
    {
       get;
    }
}
