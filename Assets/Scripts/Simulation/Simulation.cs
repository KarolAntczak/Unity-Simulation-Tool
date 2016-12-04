using UnityEngine;

/// <summary>
/// Managing simulation state
/// </summary>
public class Simulation : MonoBehaviour {

    /// <summary>
    /// Determines whether simulation is now running
    /// </summary>
    public static bool IsRunning
    {
        get;
        private set;
    }

    /// <summary>
    /// Total simulation time
    /// </summary>
    public static float TotalTime
    {
        get;
        private set;
    }

    /// <summary>
    /// Simulation speed multiplier
    /// </summary>
    public static float Speed
    {
        get;
        set;
    }

    /// <summary>
    /// Starts simulation
    /// </summary>
    public void StartSimulation()
    {
        IsRunning = true;
    }

    /// <summary>
    /// Pauses simulation
    /// </summary>
    public void PauseSimulation()
    {
        IsRunning = false;
    }

    /// <summary>
    /// Stop simulation
    /// </summary>
    public void StopSimulation()
    {
        IsRunning = false;
        TotalTime = 0;

        Request[] requests = FindObjectsOfType<Request>();

        foreach (var request in requests)
        {
            Destroy(request.gameObject);
        }

        Node[] nodes = FindObjectsOfType<Node>();
        foreach(var node in nodes)
        {
            node.Reset();
        }
    }

    void Start()
    {
        Speed = 1;
    }

    void Update()
    {
        if (IsRunning)
        {
            TotalTime += Time.deltaTime*Speed;
        }
    }

}
