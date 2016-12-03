using UnityEngine;

/// <summary>
/// Deletes currently selected object
/// </summary>
public class DeleteSelectedObject : MonoBehaviour {

    public void Delete()
    {
        Destroy(SelectObject.SelectedObject);
    }



}
