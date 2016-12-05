using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enqueues requests and sends them further after some time. 
/// </summary>
public class Queue : Node {

    public int ServingTime = 3;
    public int MaxRequestCount = 3;

    private float lastServingTime = 0;

    List<Request> requests = new List<Request>();

    /// <summary>
    /// Queuing strategy
    /// </summary>
    public IQueuing<Request> Queuing = new RandomQueue<Request>();

    public override void Process(Request request)
    {
        if (requests.Count < MaxRequestCount)
        {
            requests.Add(request);
            request.Stop();
        } 
        else
        {
            Destroy(request);
        }
    }

    public override void Reset()
    {
        requests.Clear();
    }

    void Update()
    {
        if (!Simulation.IsRunning)
        {
            return;
        }

        if (requests.Count > 0)
        {
            float currentTime = Time.fixedTime * Simulation.Speed;
            if (lastServingTime + ServingTime < currentTime)
            {
                lastServingTime = currentTime;
                Request request = NextRequest;
                request.Redirect(RandomOutgoingConnection);
            }
        }
    }

    Request NextRequest
    {
        get
        {
            return Queuing.GetNextElement(requests);
        }
    }

}
