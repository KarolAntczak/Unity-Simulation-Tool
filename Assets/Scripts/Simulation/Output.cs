using System;
using UnityEngine;

/// <summary>
/// Output consumes all incoming Requests, destroying them
/// </summary>
public class Output : Router {

    public override void Redirect(Request request)
    {
        request.Redirect(transform,null);
        Debug.Log("REDIRECT: " + gameObject.name);
    }

    void Update () {
	    foreach (Request request in GetComponentsInChildren<Request>())
        {
            Destroy(request);
        }
	}
}
