using UnityEngine;
using System.Collections;

/// <summary>
/// Connection between two simulation objects
/// </summary>
public class Connection : MonoBehaviour {

    private GameObject StartObject;
    private GameObject EndObject;

	void Update () {
        if (StartObject != null)
        {
            var lineRenderer = GetComponent<LineRenderer>();
            lineRenderer.SetPosition(0, StartObject.transform.position);

            if (EndObject != null)
            {
                lineRenderer.SetPosition(1, EndObject.transform.position);
            } 
            else
            {
                lineRenderer.SetPosition(1, Camera.main.ScreenToWorldPoint(Input.mousePosition));
            }
        }       
    }

    public void SetConnection(GameObject start, GameObject end)
    {
        StartObject = start;
        EndObject = end;
    }
}
