using UnityEngine;
using System.Collections.Generic;

public class Source : MonoBehaviour {

    public GameObject RequestPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //TODO: Add random-based intensity
	    if (Time.fixedTime %2 ==0)
        {
            List<Connection> cons = OutgoingConnections;

            if (cons.Count>0)
            {
                //TODO: Add routing rules
                Request request = Instantiate(RequestPrefab).GetComponent<Request>();
                Connection con = cons[0];
                request.Redirect(transform, con.EndObject.transform);
            }

        }
	}

    List<Connection> OutgoingConnections
    {
        get
        {
            List<Connection> connections = new List<Connection>(GetComponentsInChildren<Connection>());
            return connections.FindAll(con => con.StartObject == gameObject);
        }
    }
}
