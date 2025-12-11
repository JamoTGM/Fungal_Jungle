using UnityEngine;
using UnityEngine.InputSystem;

public class Draggable : MonoBehaviour
{
    private Camera cam;
    private bool isDragging = false;
    private Rigidbody2D rb;
    private Vector3 offset;

    void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
    }

    void OnMouseDown()
    {
        Vector3 mouseWorld = cam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        offset = transform.position - new Vector3(mouseWorld.x, mouseWorld.y, transform.position.z);
        isDragging = true;
    }

    void OnMouseUp()
    {
        isDragging = false;
    }

    void FixedUpdate()
    {
        if (isDragging)
        {
            Vector3 mouseWorld = cam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            Vector3 targetPos = new Vector3(mouseWorld.x, mouseWorld.y, transform.position.z) + offset;
            rb.MovePosition(targetPos);
        }
    }
}

