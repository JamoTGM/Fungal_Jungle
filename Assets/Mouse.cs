using UnityEngine;

public class MouseFollowAfterTrigger : MonoBehaviour
{
    public float followSpeed = 8f; // Lower = more lag (tadpole feel)

    private bool mouseControlEnabled = false;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (!mouseControlEnabled) return;

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0f;

        Vector3 targetPos = mainCamera.ScreenToWorldPoint(mousePos);
        targetPos.z = 0f;

        // Smooth trailing movement
        transform.position = Vector3.Lerp(
            transform.position,
            targetPos,
            followSpeed * Time.deltaTime
        );
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ControlZone"))
        {
            mouseControlEnabled = true;
        }
    }
}

