using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controller for monitor parameters
/// </summary>
public class MonitorParamsController : MonoBehaviour {

    public Text RequestsProcessed;
    public Text RequestsIntensity;

    void Update () {

        if (SelectObject.SelectedObject)
        {
            Monitor monitor = SelectObject.SelectedObject.GetComponent<Monitor>();

            if (monitor)
            {
                RequestsProcessed.text = monitor.RequestsProcessed.ToString();
                RequestsIntensity.text = monitor.RequestsIntensity.ToString();
            }
        }
    }
}
