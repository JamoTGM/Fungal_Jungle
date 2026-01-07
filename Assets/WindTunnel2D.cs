using UnityEngine;

public class WindTunnel2D : MonoBehaviour
{
    [Header("Flow Settings")]
    public float forceStrength = 15f;
    public float maxSpeed = 8f;

    private Vector2 flowDirection;

    void Awake()
    {
        // Tunnel direction = its local right direction
        flowDirection = transform.right.normalized;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        Rigidbody2D rb = other.attachedRigidbody;
        if (rb == null) return;

        // Optional: only affect certain objects
        if (!rb.CompareTag("WindAffectable")) return;

        // Apply continuous force
        rb.AddForce(flowDirection * forceStrength, ForceMode2D.Force);

        // Clamp max velocity so it feels like flowing water
        if (rb.linearVelocity.magnitude > maxSpeed)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }
    }
}

