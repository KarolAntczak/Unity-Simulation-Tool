using UnityEngine;
using UnityEngine.UI;

public class ShowStatisticsWindow : MonoBehaviour {

    public Window StatisticsWindow;

    public void Show()
    {
        StatisticsWindow.Show();
    }

    public void Enable()
    {
        GetComponent<Button>().interactable = SelectObject.SelectedObject != null && SelectObject.SelectedObject.GetComponent<Queue>() != null;
    }
}
