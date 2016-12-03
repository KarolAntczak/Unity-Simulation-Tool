/// <summary>
/// Deterministic distribution
/// </summary>
public class DeterministicDistribution: IDistribution
{
    public float Value = 1;

    public float NextValue
    {
        get
        {
            return Value;
        }
    }
}