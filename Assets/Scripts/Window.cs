
using UnityEngine;

/// <summary>
/// Window
/// </summary>
public class Window : MonoBehaviour
{
    /// <summary>
    /// Show context menu in mouse position
    /// </summary>
    public void Show()
    {
        gameObject.SetActive(true);
        transform.position = Input.mousePosition;
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