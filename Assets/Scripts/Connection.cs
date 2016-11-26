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
        if (StartObject != null)
        {
            var lineRenderer = GetComponent<LineRenderer>();
            lineRenderer.SetPosition(0, Vector3.zero);
            
            if (EndObject != null)
            {
                lineRenderer.SetPosition(1, EndObject.transform.position - StartObject.transform.position);
            } 
            else
            {
                lineRenderer.SetPosition(1, Camera.main.ScreenToWorldPoint(Input.mousePosition) - StartObject.transform.position);
            }
        }       
    }

    public void SetConnection(GameObject start, GameObject end)
    {
        StartObject = start;
        EndObject = end;
    }
}
