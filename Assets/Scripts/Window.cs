
using UnityEngine;

/// <summary>
/// Window
/// </summary>
public class Window : MonoBehaviour
{
    public bool Centered = false;
    /// <summary>
    /// Show context menu in mouse position
    /// </summary>
    public void Show()
    {
        gameObject.SetActive(true);
        transform.position = Centered ? new Vector3(Screen.width/2, Screen.height/2,0) : Input.mousePosition;
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