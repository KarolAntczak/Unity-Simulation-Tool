using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Shows appropriate properties window for selected object
/// </summary>
public class ShowPropertiesWindow : MonoBehaviour {

    public Window SourceProperties;
    public Window QueueProperties;
    public Window RouterProperties;
    public Window ConnectionProperties;

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
        else if (selected.GetComponent<Router>())
        {
            ShowWindow(RouterProperties);
        }
        else if (selected.GetComponent<Connection>())
        {
            ShowWindow(ConnectionProperties);
        }
    }
    
    private void ShowWindow(Window window)
    {
        if (window == null)
        {
            Debug.LogError("Trying to show null window!");
            return;
        }
        window.Show();
    }

    public void Enable()
    {
        GameObject selected = SelectObject.SelectedObject;

        GetComponent<Button>().interactable = selected &&
             (  selected.GetComponent<Source>()
             || selected.GetComponent<Queue>()
             || selected.GetComponent<Router>()
             || selected.GetComponent<Connection>()
             );
    }
}
