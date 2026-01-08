using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class TadpoleMousePhysics : MonoBehaviour
{
    public float forceStrength = 15f;

    private bool mouseControlEnabled = false;
    private Rigidbody2D rb;
    private Camera mainCamera;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        mainCamera = Camera.main;
        if (mainCamera == null)
        {
            Debug.LogError("TadpoleMousePhysics: No Main Camera found! Make sure your camera is tagged 'MainCamera'.");
        }
    }

    void FixedUpdate()
    {
        if (!mouseControlEnabled || mainCamera == null) return;

        Vector3 mousePos = Input.mousePosition;
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

