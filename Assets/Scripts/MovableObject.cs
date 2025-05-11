using UnityEngine;

public class MovableObject : MonoBehaviour 
{
    private Vector3 offset;
    private bool isHeld = false;
    private Vector3 originalScale;
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
        originalScale = transform.localScale;
    }

    void OnMouseDown()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        offset = transform.position - new Vector3(mousePos.x, mousePos.y, transform.position.z);
        isHeld = true;
        transform.localScale = originalScale * 1.2f;
    }

    void OnMouseUp()
    {
        isHeld = false;
        transform.localScale = originalScale;
    }

    void Update()
    {
        if (isHeld)
        {
            Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePos.x, mousePos.y, transform.position.z) + offset;
        }
    }
}