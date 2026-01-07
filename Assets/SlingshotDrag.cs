using UnityEngine;

public class SlingshotDrag : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 startPosition;
    public float maxDragDistance = 2f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = rb.position;
    }

    void OnMouseDrag()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePos - startPosition;

        if (direction.magnitude > maxDragDistance)
            direction = direction.normalized * maxDragDistance;

        rb.position = startPosition + direction;
    }

    void OnMouseUp()
    {
        // Let physics take over and snap back
        rb.linearVelocity = Vector2.zero;
    }
}

