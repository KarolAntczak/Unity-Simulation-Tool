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
        Vector3 currentPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 8.4f));
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
