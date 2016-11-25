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
            lastPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            isDragging = false;
        }

        if (isDragging)
        {
            Vector3 delta = (Input.mousePosition - lastPosition)* Speed;
            
            transform.Translate(delta.x,0,delta.y);
            Debug.Log(delta);
            lastPosition = Input.mousePosition;
        }
    }

}
