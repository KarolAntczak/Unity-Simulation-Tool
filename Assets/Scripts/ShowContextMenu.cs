using UnityEngine;

/// <summary>
/// Displays context menu when right-clicking the object
/// </summary>
public class ShowContextMenu : MonoBehaviour {

    private ContextMenu ContextMenu;

    void Start()
    {
        ContextMenu = FindObjectOfType<ContextMenu>();
    }

	void Update () {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
            if (Physics.Raycast(ray, out hit))
            {
                ContextMenu.Show();
            }
            else
            {
                ContextMenu.Hide();
            }
        } 
    }
}
