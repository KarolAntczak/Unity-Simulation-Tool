using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class SimulationStateText : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        string text;

        if (Simulation.IsRunning)
        {
            text = string.Format("Simulation is running. Simulation time: {0:F2} s", Simulation.TotalTime);
        }
        else
        {
            text = string.Format("Simulation is not running. Simulation time: {0:F2} s", Simulation.TotalTime);
        }

        GetComponent<Text>().text = text;
	}
}
