using UnityEngine;
using System.Collections;

/// <summary>
/// Connection between two simulation objects
/// </summary>
[ExecuteInEditMode]
public class Connection : MonoBehaviour {

    public Transform StartObject;
    public Transform EndObject;

    /// <summary>
    /// Probability of redirecting request to this connection
    /// </summary>
    public float RedirectingProbability = 1;

	void Update () {
        if (StartObject != null)
        {
            if (EndObject != null)
            {
                updateLine(StartObject.position, EndObject.position);
            } 
            else
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                var xy = new Plane(Vector3.up, new Vector3(0, 1, 0));
                float distance;
                xy.Raycast(ray, out distance);
                var currentPosition = ray.GetPoint(distance);
                currentPosition.y = StartObject.position.y;
                updateLine(StartObject.position, currentPosition);
            }
        }
    }

    /// <summary>
    /// Updates line renderer and collider
    /// </summary>
    /// <param name="startPosition">Line start</param>
    /// <param name="endPosition">Line end</param>
    private void updateLine(Vector3 startPosition, Vector3 endPosition)
    {
        Vector3 center = Vector3.Lerp(startPosition, endPosition, 0.5f);
        transform.position = center;

        var lineRenderer = GetComponent<LineRenderer>();        
        var length = Vector3.Distance(startPosition, endPosition);

        // connection pivot is between start position and end position
        lineRenderer.SetPosition(0, Vector3.back * length * 0.5f);
        lineRenderer.SetPosition(1, Vector3.forward * length * 0.5f);

        transform.LookAt(endPosition);

        CapsuleCollider collider = GetComponent<CapsuleCollider>();
        collider.height = length;
    }

    public void SetConnection(Transform start, Transform end)
    {
        StartObject = start;
        EndObject = end;
        CapsuleCollider collider = GetComponent<CapsuleCollider>();
        collider.enabled = (EndObject != null);
    }
}
