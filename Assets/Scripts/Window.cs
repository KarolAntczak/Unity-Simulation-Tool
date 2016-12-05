
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Window
/// </summary>
public class Window : MonoBehaviour
{
    /// <summary>
    /// Called when window is shown
    /// </summary>
    public UnityEvent OnShow;

    public bool Centered = false;
    /// <summary>
    /// Show context menu in mouse position
    /// </summary>
    public void Show()
    {
        gameObject.SetActive(true);
        transform.position = Centered ? new Vector3(Screen.width/2, Screen.height/2,0) : Input.mousePosition;

        if (OnShow!=null)
        {
            OnShow.Invoke();
        }
    }

    /// <summary>
    /// Hide context menu
    /// </summary>
    public void Hide()
    {
        gameObject.SetActive(false);
        transform.position = Vector3.zero;
    }
}