using UnityEngine;

/// <summary>
/// Creates new simulation object
/// </summary>
public class CreateObject : MonoBehaviour {

    /// <summary>
    /// Parent of object to create
    /// </summary>
    public Transform Parent;

    /// <summary>
    /// Prefab of objct to create
    /// </summary>
    public GameObject Prefab;

    /// <summary>
    /// Create new simulation object
    /// </summary>
	public void Create()
    {
        Instantiate(Prefab,Parent);
    }
}
