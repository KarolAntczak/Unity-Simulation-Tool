using UnityEngine;
using System.Collections;

public class MakeConnection : MonoBehaviour {

    private GameObject StartObject;
    private GameObject EndObject;

    public GameObject ConnectionPrefab;

    private Connection connection;

    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
	
        if (StartObject!=null && EndObject==null)
        {
            if (SelectObject.SelectedObject != StartObject)
            {
                EndObject = SelectObject.SelectedObject;
                Debug.Log("Created connection: " + StartObject + ", " + EndObject);
            }
            connection.GetComponent<Connection>().SetConnection(StartObject, EndObject);
        }
	}

    public void SelectStartObject()
    {
        StartObject = SelectObject.SelectedObject;
        EndObject = null;

        connection = Instantiate(ConnectionPrefab).GetComponent<Connection>();
    }
}
