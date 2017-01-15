using UnityEngine;
using UnityEngine.UI;

public class OutputStatisticsController : MonoBehaviour {
    
    public Text RequestsResponseTime;
	
	// Update is called once per frame
	void Update () {
        if (SelectObject.SelectedObject)
        {
            Output output = SelectObject.SelectedObject.GetComponent<Output>();

            if (output)
            {
                RequestsResponseTime.text = output.MeanResponseTime.ToString();
            }
        }
    }
}
