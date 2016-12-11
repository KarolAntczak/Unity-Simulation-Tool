using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Enables button only when selected item is node
/// </summary>
public class EnableWhenNodeSelected : MonoBehaviour {

    /// <summary>
    /// Enables/disables button if selected object is Node
    /// </summary>
    public void Enable()
    {
        GetComponent<Button>().interactable = SelectObject.SelectedObject!=null && SelectObject.SelectedObject.GetComponent<Node>() != null;
    }

}
