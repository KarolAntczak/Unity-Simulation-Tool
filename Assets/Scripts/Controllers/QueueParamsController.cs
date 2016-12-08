using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controller for queue parameters
/// </summary>
public class QueueParamsController : MonoBehaviour {

    public Dropdown QueuingDropdown;
    public InputField MaxLengthInput;
    public GameObject DistributionParamsController;

    public void Load()
    {
        Queue queue = SelectObject.SelectedObject.GetComponent<Queue>();
        IQueuing<Request> queuing = queue.Queuing;

        if (queuing is Fifo<Request>)
        {
            QueuingDropdown.captionText.text = "FIFO";
        }
        else if (queuing is Lifo<Request>)
        {
            QueuingDropdown.captionText.text = "LIFO";
        }
        else if (queuing is RandomQueue<Request>)
        {
            QueuingDropdown.captionText.text = "Random";
        }

        MaxLengthInput.text = queue.MaxRequestCount.ToString();
        DistributionParamsController.GetComponent<DistributionParamsController>().SetDistribution(queue.ServingDistribution);
    }

    public void Apply()
    {
        Queue queue = SelectObject.SelectedObject.GetComponent<Queue>();

        if (QueuingDropdown.captionText.text == "FIFO")
        {
            queue.Queuing = new Fifo<Request>();
        }
        else if (QueuingDropdown.captionText.text == "LIFO")
        {
            queue.Queuing = new Lifo<Request>();
        }
        else if (QueuingDropdown.captionText.text == "Random")
        {
            queue.Queuing = new RandomQueue<Request>();
        }

        queue.MaxRequestCount = int.Parse(MaxLengthInput.text);
        queue.SetServingDistribution(DistributionParamsController.GetComponent<DistributionParamsController>().GetDistribution());
    }
}
