using UnityEngine;
using UnityEngine.UI;

public class QueueStatisticsParamsController : MonoBehaviour
{
    public Text MeanRequestsCount;
    public Text MeanProcessTime;

    void Update()
    {
        if (SelectObject.SelectedObject)
        {
            Queue queue = SelectObject.SelectedObject.GetComponent<Queue>();

            if (queue)
            {
                MeanProcessTime.text = queue.MeanRequestProcessingTime.ToString();
                MeanRequestsCount.text = queue.MeanRequestCount.ToString();
            }
        }
    }
}
