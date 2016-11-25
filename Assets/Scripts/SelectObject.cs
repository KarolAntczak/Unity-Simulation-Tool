using UnityEngine;
using System.Collections;

/// <summary>
/// Displays selection when clicking an object
/// </summary>
public class SelectObject : MonoBehaviour {

    public GameObject SelectionPrefab;
    private GameObject selectionInstance;

    private bool selected = false;

    void Update()
    {
        if (selected)
        {
            if (selectionInstance == null)
            {
                selectionInstance = Instantiate(SelectionPrefab);
                selectionInstance.transform.SetParent(transform);
                selectionInstance.transform.localPosition = Vector3.zero;
            }
        }
        else if (Input.GetMouseButtonDown(0))
        {
            Destroy(selectionInstance);
        }

        selected = false;
    }

    void OnMouseDown()
    {
        selected = true;
    }

}
