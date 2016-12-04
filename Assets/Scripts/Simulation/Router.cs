using UnityEngine;


//Routers redirets requests 
public abstract class Router : MonoBehaviour {

    /// <summary>
    /// Redirecsts given Request 
    /// </summary>
    public abstract void Redirect(Request request);
}
