using UnityEngine;
using System.Collections;

/// <summary>
/// Connection between two simulation objects
/// </summary>
[ExecuteInEditMode]
public class Connection : MonoBehaviour {

    public GameObject StartObject;
    public GameObject EndObject;

	void Update () {
        var lineRenderer = GetComponent<LineRenderer>();

        if (StartObject != null)
        {
            // zero because it is instantiated as direct child under source node
            lineRenderer.SetPosition(0, Vector3.zero);
            
            if (EndObject != null)
            {
                lineRenderer.SetPosition(1, EndObject.transform.position - StartObject.transform.position);
            } 
            else
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                var xy = new Plane(Vector3.up, new Vector3(0, 1, 0));
                float distance;
                xy.Raycast(ray, out distance);
                var currentPosition = ray.GetPoint(distance);
                currentPosition.y = StartObject.transform.position.y;
                lineRenderer.SetPosition(1, currentPosition - StartObject.transform.position);
            }
        }
    }

    public void SetConnection(GameObject start, GameObject end)
    {
        StartObject = start;
        EndObject = end;
    }
}
