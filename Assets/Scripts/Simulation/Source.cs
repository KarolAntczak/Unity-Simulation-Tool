using UnityEngine;

public class Source : Router {

    public GameObject RequestPrefab;

    public IDistribution Distribution = new UniformDistribution();

    private float nextRequestTime;

	// Use this for initialization
	void Start () {
        nextRequestTime = Time.fixedTime + Distribution.NextValue;
    }
	
	// Update is called once per frame
	void Update () {

        if (OutgoingConnections.Count > 0)
        {
            if (Time.fixedTime > nextRequestTime)
            {
                Request request = Instantiate(RequestPrefab).GetComponent<Request>();
                Redirect(request);
                nextRequestTime = Time.fixedTime + Distribution.NextValue;
            }
        }
	}
}
