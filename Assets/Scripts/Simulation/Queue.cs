using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enqueues requests and sends them further after some time. 
/// </summary>
public class Queue : Node {

    public int ServingTime = 3;
    public int MaxRequestCount = 3;

    private float lastServingTime = 0;

    Queue<Request> requests = new Queue<Request>();

    public override void Process(Request request)
    {
        if (requests.Count < MaxRequestCount)
        {
            requests.Enqueue(request);
            request.Stop();
        } 
        else
        {
            Destroy(request);
        }
    }

    void Update()
    {
        if (requests.Count > 0)
        {
            if (lastServingTime + 3 < Time.fixedTime )
            {
                lastServingTime = Time.fixedTime;
                Request request = requests.Dequeue();
                request.Redirect(RandomOutgoingConnection);
            }
        }
    }

}
