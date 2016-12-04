using UnityEngine;
using System.Collections;

/// <summary>
/// Single simulation request
/// </summary>
public class Request : MonoBehaviour {

    public float Speed = 1;

    public Transform From;
    public Transform To;

    private float progress = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (To!=null)
        {
            transform.position = Vector3.Lerp(From.position, To.position, progress);
            progress += Time.deltaTime * Speed;

            if (progress >=1)
            {
                From = To;
                transform.parent = From;
                To.GetComponent<Node>().Process(this);
            }
        }
	}

    public void Stop()
    {
        To = null;
    }

    public void Redirect(Transform to)
    {
        Redirect(To, to);
    }

    public void Redirect(Connection connection)
    {
        Redirect(connection.StartObject.transform, connection.EndObject.transform);
    }

    public void Redirect(Transform from, Transform to)
    {
        transform.parent = from;
        From = from;
        To = to;
        progress = 0;
    }
}
