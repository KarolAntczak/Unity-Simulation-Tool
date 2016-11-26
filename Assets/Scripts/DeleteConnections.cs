using UnityEngine;
using System.Collections;

/// <summary>
/// Deletes all connection associated with selected object
/// </summary>
public class DeleteConnections : MonoBehaviour {
	
    public void Delete()
    {
        Connection[] connections = FindObjectsOfType<Connection>();

        foreach (var connection in connections)
        {
            if (connection.StartObject==SelectObject.SelectedObject ||
                connection.EndObject == SelectObject.SelectedObject )
            {
                Destroy(connection.gameObject);
            }
        }
    }
}
