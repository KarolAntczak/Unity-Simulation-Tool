using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enqueues requests and sends them further after some time. 
/// </summary>
public class Queue : Node {

    private readonly int ServingSlotsCount = 1;

    public IDistribution ServingDistribution = new DeterministicDistribution();
    public int MaxRequestCount = 3;

    private float servingTime = 0;
    private float lastServingTime = 0;

    List<Request> requests = new List<Request>();

    private float totalRequestCount = 0f;
    private float totalProcessingTime = 0f;

    private float requestInQueueCount = 0f;

    public Queue()
    {
        servingTime = ServingDistribution.NextValue;
    }

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
            NumberInQueueChanged();
        } 
        else
        {
            Destroy(request);
        }
    }

    public override void Reset()
    {
        totalRequestCount = 0f;
        totalProcessingTime = 0f;
        requestInQueueCount = 0f;
        requests.Clear();
    }

    void Update()
    {
        if (!Simulation.IsRunning)
        {
            return;
        }

        if (requests.Count > 0 && OutgoingConnections.Count > 0)
        {
            float currentTime = Time.fixedTime * Simulation.Speed;
            if (lastServingTime + servingTime < currentTime)
            {
                lastServingTime = currentTime;
                Request request = NextRequest;
                request.Redirect(RandomOutgoingConnection);

                totalRequestCount++;
                totalProcessingTime += servingTime;
                NumberInQueueChanged();
                servingTime = ServingDistribution.NextValue;
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

    public void SetServingDistribution(IDistribution distribution)
    {
        ServingDistribution = distribution;
        servingTime = ServingDistribution.NextValue;
    }

    public float MeanRequestProcessingTime
    {
        get
        {
            if (totalRequestCount == 0)
            {
                return 0f;
            }
            return totalProcessingTime / totalRequestCount;
        }
    }

    public float MeanRequestCount
    {
        get
        {
            return requestInQueueCount / Simulation.TotalTime;
        }
    }

    private void NumberInQueueChanged()
    {
        // one request is always being processed and not in queue
        requestInQueueCount += (requests.Count > ServingSlotsCount ? (requests.Count - ServingSlotsCount) : 0);
    }
}
