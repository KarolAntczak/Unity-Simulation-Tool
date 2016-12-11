using UnityEngine;
using System.Collections;

public class MakeConnection : MonoBehaviour {

    private Transform StartObject;
    private Transform EndObject;

    public GameObject ConnectionPrefab;

    private Connection connection;

    void Start () {

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(1) && connection != null)
        {
            // Cancel selection
            StartObject = null;
            EndObject = null;
            Destroy(connection.gameObject);
        }


        if (StartObject!=null && EndObject==null)
        {
            if (SelectObject.SelectedObject.transform != StartObject)
            {
                EndObject = SelectObject.SelectedObject.transform;
                connection.GetComponent<Connection>().SetConnection(StartObject, EndObject);
                Debug.Log("Created connection: " + StartObject + ", " + EndObject);

                StartObject = null;
                EndObject = null;
                connection = null;
            }
            else
            {
                connection.GetComponent<Connection>().SetConnection(StartObject, null);
            }
        }
	}

    public void SelectStartObject()
    {
        StartObject = SelectObject.SelectedObject.transform;
        EndObject = null;

        connection = Instantiate(ConnectionPrefab).GetComponent<Connection>();
        connection.transform.parent = StartObject.transform;
        connection.transform.localPosition = Vector3.zero;
    }
}
