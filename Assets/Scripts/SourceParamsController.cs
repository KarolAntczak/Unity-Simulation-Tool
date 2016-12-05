using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controller for source parameters 
/// </summary>
public class SourceParamsController : MonoBehaviour {

    public GameObject MinInput;
    public GameObject MaxInput;
    public GameObject ValueInput;
    public GameObject MeanInput;
    public GameObject DeviationInput;

    public void UpdateDistributionParamsVisibility()
    {
        string distribution = gameObject.GetComponent<Dropdown>().captionText.text;

        bool normal = distribution == "Normal";
        bool uniform = distribution == "Uniform";
        bool deterministic = distribution == "Deterministic";

        MinInput.SetActive(uniform);
        MaxInput.SetActive(uniform);
        ValueInput.SetActive(deterministic);
        MeanInput.SetActive(normal);
        DeviationInput.SetActive(normal);
    }

    public void Load()
    {
        IDistribution dist = SelectObject.SelectedObject.GetComponent<Source>().Distribution;
        Dropdown dropdown = gameObject.GetComponent<Dropdown>();

        if (dist is NormalDistribution)
        {
            dropdown.captionText.text = "Normal";
            DeviationInput.GetComponent<InputField>().text = ((NormalDistribution)dist).Deviation.ToString();
            MeanInput.GetComponent<InputField>().text = ((NormalDistribution)dist).Mean.ToString();
        } else if (dist is UniformDistribution)
        {
            dropdown.captionText.text = "Uniform";
            MinInput.GetComponent<InputField>().text = ((UniformDistribution)dist).Min.ToString();
            MaxInput.GetComponent<InputField>().text = ((UniformDistribution)dist).Max.ToString();
        } else if (dist is DeterministicDistribution)
        {
            dropdown.captionText.text = "Deterministic";
            ValueInput.GetComponent<InputField>().text = ((DeterministicDistribution)dist).Value.ToString();
        }
        UpdateDistributionParamsVisibility();
    }

    /// <summary>
    /// Apply distribution to current active source
    /// </summary>
    public void Apply()
    {
        string distribution = gameObject.GetComponent<Dropdown>().captionText.text;

        bool normal = distribution == "Normal";
        bool uniform = distribution == "Uniform";
        bool deterministic = distribution == "Deterministic";

        IDistribution dist = null;

        if (normal)
        {
            dist = new NormalDistribution()
            {
                Deviation = float.Parse(DeviationInput.GetComponent<InputField>().text),
                Mean = float.Parse(MeanInput.GetComponent<InputField>().text)
            };
        }
        else if (uniform)
        {
            dist = new UniformDistribution()
            {
                Min = float.Parse(MinInput.GetComponent<InputField>().text),
                Max = float.Parse(MaxInput.GetComponent<InputField>().text)
            };
        }
        else if (deterministic)
        {
            dist = new DeterministicDistribution()
            {
                Value = float.Parse(ValueInput.GetComponent<InputField>().text)
            };
        }

        SelectObject.SelectedObject.GetComponent<Source>().Distribution = dist;
    }

}
