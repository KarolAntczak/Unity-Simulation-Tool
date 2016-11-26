using UnityEngine;

/// <summary>
/// Deletes currently selected object
/// </summary>
public class DeleteSelectedObject : MonoBehaviour {

    public void Delete()
    {
        Debug.Log(SelectObject.SelectedObject);
        Destroy(SelectObject.SelectedObject);
    }

}
