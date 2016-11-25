using UnityEngine;
using System.Collections;

/// <summary>
/// Moves object on mouse dragging
/// </summary>
public class MoveOnMouseDrag : MonoBehaviour {

    public float Speed = 1;

    bool isDragging = false;
    Vector3 lastPosition;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isDragging = true;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            isDragging = false;
        }

        Vector3 currentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (isDragging)
        {
            Vector3 delta = (currentPosition - lastPosition)* Speed;      
            transform.Translate(delta);
        }
        lastPosition = currentPosition;
    }

}
