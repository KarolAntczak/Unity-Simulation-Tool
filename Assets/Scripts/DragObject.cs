using UnityEngine;

public class DragObject : MonoBehaviour {

    public float Speed = 1;

    bool isDragging = false;
    Vector3 lastPosition;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 currentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (isDragging)
        {
            Vector3 delta = (currentPosition - lastPosition) * Speed;

            transform.Translate(delta);
        }
        lastPosition = currentPosition;
    }

    void OnMouseDown()
    {
        isDragging = true;
    }

    void OnMouseUp()
    {
        isDragging = false;
    }


}
