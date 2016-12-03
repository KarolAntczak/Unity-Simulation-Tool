using UnityEngine;
using System.Collections.Generic;

public class Source : MonoBehaviour {

    public GameObject RequestPrefab;

    public IDistribution Distribution = new UniformDistribution();

    private float nextRequestTime;

	// Use this for initialization
	void Start () {
        nextRequestTime = Time.fixedTime + Distribution.NextValue;
    }
	
	// Update is called once per frame
	void Update () {

	    if (Time.fixedTime > nextRequestTime)
        {
            List<Connection> cons = OutgoingConnections;

            if (cons.Count>0)
            {
                Request request = Instantiate(RequestPrefab).GetComponent<Request>();
                Connection con = cons[0];
                request.Redirect(transform, con.EndObject.transform);
                nextRequestTime = Time.fixedTime + Distribution.NextValue;
            }

        }
	}

    List<Connection> OutgoingConnections
    {
        get
        {
            return new List<Connection>(GetComponentsInChildren<Connection>());
        }
    }
}
