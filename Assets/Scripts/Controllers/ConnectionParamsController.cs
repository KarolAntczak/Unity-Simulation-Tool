using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controller for connection parameters
/// </summary>
public class ConnectionParamsController : MonoBehaviour
{

    public InputField RedirectingProbabilityInput;

    public void Load()
    {
        Connection connection = SelectObject.SelectedObject.GetComponent<Connection>();
        RedirectingProbabilityInput.text = connection.RedirectingProbability.ToString();
    }

    public void Apply()
    {
        Connection connection = SelectObject.SelectedObject.GetComponent<Connection>();
        connection.RedirectingProbability = float.Parse(RedirectingProbabilityInput.text);
    }
}
