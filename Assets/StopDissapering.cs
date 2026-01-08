using UnityEngine;

public class MouseFollowPhysics : MonoBehaviour
{
    public float forceStrength = 15f;

    private bool mouseControlEnabled = false;
    private Rigidbody2D rb;
    private Camera mainCamera;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
    }

    void FixedUpdate()
    {
        if (!mouseControlEnabled) return;

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0f;

        Vector2 targetPos = mainCamera.ScreenToWorldPoint(mousePos);
        Vector2 direction = targetPos - rb.position;

        rb.AddForce(direction * forceStrength);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ControlZone"))
        {
            mouseControlEnabled = true;
        }
    }
}

