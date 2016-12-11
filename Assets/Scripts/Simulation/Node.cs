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
    /// List of connections coming out from this node
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

    /// <summary>
    /// List of connections coming in to this node
    /// </summary>
    public List<Connection> IncomingConnections
    {
        get
        {
            var connections = new List<Connection>(FindObjectsOfType<Connection>());
            return connections.FindAll( (Connection connection) => connection.EndObject == transform );
        }
    }

    /// <summary>
    /// Destroy all incoming connection when destroying this node
    /// </summary>
    void OnDestroy()
    {
        var incomingConnections = IncomingConnections;

        foreach (var connection in incomingConnections)
        {
            Destroy(connection.gameObject);
        }
    }
}
