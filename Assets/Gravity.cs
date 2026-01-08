using UnityEngine;

public class Gravity : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool gravityOn = false;

    public float gravityStrength = 1f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
    }

    private bool canToggle = true;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!canToggle || !other.CompareTag("GravityToggle")) return;

        gravityOn = !gravityOn;
        rb.gravityScale = gravityOn ? gravityStrength : 0f;

        canToggle = false;
        Invoke(nameof(ResetToggle), 0.3f);
    }

    void ResetToggle()
    {
        canToggle = true;
    }

}
