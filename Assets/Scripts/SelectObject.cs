using UnityEngine;
using System.Collections;

/// <summary>
/// Displays selection when clicking an object
/// </summary>
public class SelectObject : MonoBehaviour {

    public GameObject SelectionPrefab;
    private GameObject selectionInstance;
    public static GameObject SelectedObject;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {     
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
            if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject() == false &&
                selectionInstance == null && Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
            {
                selectionInstance = Instantiate(SelectionPrefab);
                selectionInstance.transform.SetParent(transform);
                selectionInstance.transform.localPosition = Vector3.zero;
                selectionInstance.transform.localRotation = Quaternion.identity;
                 SelectedObject = gameObject;
                Debug.Log("Selected: " + SelectedObject.name);
            }
            else 
            {
                Destroy(selectionInstance);
            }
        }
    }
}
