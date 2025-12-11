using UnityEngine;

public class DraggableMerge : MonoBehaviour
{
    public string mergeTag;              // Tag this can merge with
    public GameObject mergeResultPrefab; // Prefab to spawn after merge

    private Camera cam;
    private Rigidbody2D rb;
    private BoxCollider2D box;
    private bool isDragging = false;
    private Vector3 offset;
    private SpriteRenderer glow;

    void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();

        // Glow child object
        Transform glowObj = transform.Find("GlowOutline");
        if (glowObj != null)
        {
            glow = glowObj.GetComponent<SpriteRenderer>();
            glow.enabled = false;
        }
    }

    void OnMouseDown()
    {
        // Calculate offset
        Vector3 mouseWorld = cam.ScreenToWorldPoint(Input.mousePosition);
        offset = transform.position - new Vector3(mouseWorld.x, mouseWorld.y, transform.position.z);

        isDragging = true;

        // Make kinematic to ignore collisions while dragging
        rb.isKinematic = true;
    }

    void OnMouseUp()
    {
        isDragging = false;

        // Restore Rigidbody
        rb.isKinematic = false;

        // Check for merge once released
        CheckMerge();
    }

    void Update()
    {
        if (isDragging)
        {
            Vector3 mouseWorld = cam.ScreenToWorldPoint(Input.mousePosition);
            mouseWorld.z = transform.position.z;
            rb.MovePosition(mouseWorld + offset);

            // Constantly check for glow
            UpdateGlow();
        }
    }

    void UpdateGlow()
    {
        if (glow == null) return;

        bool canMerge = false;

        Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position, box.size, 0f);

        foreach (Collider2D hit in hits)
        {
            if (hit.gameObject != gameObject && hit.CompareTag(mergeTag))
            {
                canMerge = true;
                break;
            }
        }

        glow.enabled = canMerge;
    }

    void CheckMerge()
    {
        Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position, box.size, 0f);

        foreach (Collider2D hit in hits)
        {
            if (hit.gameObject != gameObject && hit.CompareTag(mergeTag))
            {
                Vector3 spawnPos = (transform.position + hit.transform.position) / 2f;

                Instantiate(mergeResultPrefab, spawnPos, Quaternion.identity);

                Destroy(hit.gameObject);
                Destroy(gameObject);
                return;
            }
        }
    }

    // Optional: draw box in editor for debugging
    void OnDrawGizmosSelected()
    {
        if (box != null)
        {
            Gizmos.color = new Color(0, 1, 0, 0.3f);
            Gizmos.DrawCube(transform.position, box.size);
        }
    }
}
