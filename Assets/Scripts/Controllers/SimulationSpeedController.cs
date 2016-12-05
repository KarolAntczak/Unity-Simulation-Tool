using UnityEngine;
using UnityEngine.UI;

public class SimulationSpeedController : MonoBehaviour {

	public void UpdateSimulationSpeed()
    {
        Simulation.Speed = GetComponent<Slider>().value;
        GetComponentInChildren<Text>().text = string.Format("Speed x{0}",(int) Simulation.Speed);
    }
}
