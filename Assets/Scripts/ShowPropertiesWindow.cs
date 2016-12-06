using UnityEngine;

/// <summary>
/// Shows appropriate properties window for selected object
/// </summary>
public class ShowPropertiesWindow : MonoBehaviour {

    public Window SourceProperties;
    public Window QueueProperties;
    public Window OutputProperties;
    public Window MonitorProperties;
    public Window RouterProperties;

    /// <summary>
    /// Show appropriate properties window
    /// </summary>
    public void Show()
    {
        GameObject selected = SelectObject.SelectedObject;

        if (selected.GetComponent<Source>())
        {
            ShowWindow(SourceProperties);
        }
        else if (selected.GetComponent<Queue>())
        {
            ShowWindow(QueueProperties);
        }
        else if (selected.GetComponent<Monitor>())
        {
            ShowWindow(MonitorProperties);
        }
        else if (selected.GetComponent<Output>())
        {
            ShowWindow(OutputProperties);
        }
        else if (selected.GetComponent<Router>())
        {
            ShowWindow(RouterProperties);
        }
    }
    
    private void ShowWindow(Window window)
    {
        if (window == null)
        {
            Debug.LogError("Trying to show null window!");
        }
        window.Show();
    }
}
