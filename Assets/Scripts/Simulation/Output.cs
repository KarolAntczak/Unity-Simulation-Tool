using System;
using UnityEngine;

/// <summary>
/// Output consumes all incoming Requests, destroying them
/// </summary>
public class Output : Node {

    public override void Process(Request request)
    {
        Destroy(request);
    }

}
