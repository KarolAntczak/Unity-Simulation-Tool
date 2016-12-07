using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controller for distibution setting UI
/// </summary>
public class DistributionParamsController : MonoBehaviour
{
    public Dropdown DistributionDropdown;

    public GameObject MinInput;
    public GameObject MaxInput;
    public GameObject ValueInput;
    public GameObject MeanInput;
    public GameObject DeviationInput;
    public GameObject IntensityInput;

    public void Load()
    {
    }

    public void UpdateDistributionParamsVisibility()
    {
        int distribution = DistributionDropdown.value;

        bool normal = distribution == 0;
        bool uniform = distribution == 1;
        bool deterministic = distribution == 2;
        bool exponential = distribution == 3;

        MinInput.SetActive(uniform);
        MaxInput.SetActive(uniform);
        ValueInput.SetActive(deterministic);
        MeanInput.SetActive(normal);
        DeviationInput.SetActive(normal);
        IntensityInput.SetActive(exponential);
    }

    public void SetDistribution(IDistribution distribution)
    {
        if (distribution is NormalDistribution)
        {
            DistributionDropdown.value = 0;
            DeviationInput.GetComponent<InputField>().text = ((NormalDistribution)distribution).Deviation.ToString();
            MeanInput.GetComponent<InputField>().text = ((NormalDistribution)distribution).Mean.ToString();
        }
        else if (distribution is UniformDistribution)
        {
            DistributionDropdown.value = 1;
            MinInput.GetComponent<InputField>().text = ((UniformDistribution)distribution).Min.ToString();
            MaxInput.GetComponent<InputField>().text = ((UniformDistribution)distribution).Max.ToString();
        }
        else if (distribution is DeterministicDistribution)
        {
            DistributionDropdown.value = 2;
            ValueInput.GetComponent<InputField>().text = ((DeterministicDistribution)distribution).Value.ToString();
        }
        else if (distribution is ExponentialDistribution)
        {
            DistributionDropdown.value = 3;
            IntensityInput.GetComponent<InputField>().text = ((ExponentialDistribution)distribution).Intensity.ToString();
        }
        UpdateDistributionParamsVisibility();
    }

    public IDistribution GetDistribution()
    {
        int distribution = DistributionDropdown.value;

        bool normal = distribution == 0;
        bool uniform = distribution == 1;
        bool deterministic = distribution == 2;
        bool exponential = distribution == 3;

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
        else if (exponential)
        {
            dist = new ExponentialDistribution()
            {
                Intensity = float.Parse(IntensityInput.GetComponent<InputField>().text)
            };
        }

        Debug.Log("Distribution chosen " + distribution);
        Debug.Log("Distribution created " + dist);

        return dist;
    }
}
