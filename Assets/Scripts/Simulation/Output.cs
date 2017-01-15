using System;
using UnityEngine;

/// <summary>
/// Output consumes all incoming Requests, destroying them
/// </summary>
public class Output : Node {

    private float totalRequestsCount;
    private float totalResponseTime;

    void Start()
    {
        totalRequestsCount = 0.0f;
        totalResponseTime = 0.0f;
    }

    public override void Process(Request request)
    {
        totalRequestsCount++;
        totalResponseTime += request.ProcessingTime;
        Destroy(request.gameObject);
    }

    public float MeanResponseTime
    {
        get {
            return totalRequestsCount == 0.0f ? 0.0f : totalResponseTime / totalRequestsCount;
        }
    }
}
