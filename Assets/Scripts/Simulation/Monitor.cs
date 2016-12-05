using UnityEngine;

/// <summary>
/// Gathers statistics about processed requests.
/// </summary>
public class Monitor : Node {

    public float RequestsProcessed = 0;
    public float RequestsIntensity = 0;

    public override void Process(Request request)
    {
        base.Process(request);
        RequestsProcessed++;
        RequestsIntensity = RequestsProcessed / Time.fixedTime;
    }

}
