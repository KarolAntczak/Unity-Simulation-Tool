using UnityEngine;

/// <summary>
/// Shows appropriate properties window for selected object
/// </summary>
public class ShowPropertiesWindow : MonoBehaviour {

    public Window SourceProperties;
    public Window QueueProperties;
    public Window OutputProperties;
    public Window MonitorProperties;

    /// <summary>
    /// Show appropriate properties window
    /// </summary>
    public void Show()
    {
        GameObject selected = SelectObject.SelectedObject;

        if (selected.GetComponent<Source>())
        {
            SourceProperties.Show();
        }
        else if (selected.GetComponent<Queue>())
        {
            QueueProperties.Show();
        }
        else if (selected.GetComponent<Monitor>())
        {
            MonitorProperties.Show();
        }
        else if (selected.GetComponent<Output>())
        {
            OutputProperties.Show();
        }
    }

}
