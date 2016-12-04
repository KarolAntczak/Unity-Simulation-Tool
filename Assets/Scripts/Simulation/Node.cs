using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Basic simulation node. Can process requests be connected to other nodes. 
/// </summary>
public abstract class Node : MonoBehaviour {

    /// <summary>
    /// Processes given Request.
    /// </summary>
    public virtual void Process(Request request)
    {
        request.Redirect(RandomOutgoingConnection);
    }

    /// <summary>
    /// Resets node to its starting state
    /// </summary>
    public virtual void Reset()
    {

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
