using UnityEngine;

public class SlingshotController : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpringJoint2D spring;
    private Vector2 startPosition;
    private Camera cam;

    [SerializeField] private float maxPullDistance = 2.5f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spring = GetComponent<SpringJoint2D>();
        cam = Camera.main;

        startPosition = rb.position;
        spring.connectedAnchor = startPosition;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Drag();
        }

        if (Input.GetMouseButtonUp(0))
        {
            Release();
        }
    }

    void Drag()
    {
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        // Only allow dragging DOWN
        Vector2 pullVector = mousePos - startPosition;
        pullVector.x = 0;
        pullVector.y = Mathf.Clamp(pullVector.y, -maxPullDistance, 0);

        rb.MovePosition(startPosition + pullVector);
    }

    void Release()
    {
        rb.linearVelocity = Vector2.zero;
    }
}

