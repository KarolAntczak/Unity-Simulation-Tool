using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controller for source parameters 
/// </summary>
public class SourceParamsController : MonoBehaviour {

    public GameObject DistributionParamsController;

    public void Load()
    {
        IDistribution dist = SelectObject.SelectedObject.GetComponent<Source>().Distribution;
        DistributionParamsController.GetComponent<DistributionParamsController>().SetDistribution(dist);
    }

    /// <summary>
    /// Apply distribution to current active source
    /// </summary>
    public void Apply()
    {
        IDistribution dist = DistributionParamsController.GetComponent<DistributionParamsController>().GetDistribution();
        SelectObject.SelectedObject.GetComponent<Source>().Distribution = dist;
    }

}
