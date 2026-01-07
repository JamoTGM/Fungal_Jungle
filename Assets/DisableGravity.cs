using UnityEngine;

public class ZeroGravityTrigger2D : MonoBehaviour
{
    [Header("Zero Gravity")]
    public float zeroGravityValue = 0f;

    [Tooltip("Optional: only affect this tag")]
    public string targetTag = "WindAffectable";

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag(targetTag)) return;

        Rigidbody2D rb = other.attachedRigidbody;
        if (rb == null) return;

        rb.gravityScale = zeroGravityValue;
    }
}


