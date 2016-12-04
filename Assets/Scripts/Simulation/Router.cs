using System.Collections.Generic;
using UnityEngine;


//Routers redirets requests 
public abstract class Router : MonoBehaviour {

    /// <summary>
    /// Redirects given Request 
    /// </summary>
    public virtual void Redirect(Request request)
    {
        request.Redirect(RandomOutgoingConnection);
    }
    
    /// <summary>
    /// List of connections coming out from this router
    /// </summary>
    public List<Connection> OutgoingConnections
    {
        get
        {
            return new List<Connection>(GetComponentsInChildren<Connection>());
        }
    }

    /// <summary>
    /// Randomly chosen ougtoing connections
    /// </summary>
    public Connection RandomOutgoingConnection
    {
        get
        {
            List<Connection> connections = OutgoingConnections;
            return connections[Random.Range(0, connections.Count)];
        }
    }
}
