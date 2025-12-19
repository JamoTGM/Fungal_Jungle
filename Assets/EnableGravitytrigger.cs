using UnityEngine;

public class EnableGravityTrigger : MonoBehaviour
{
    public float gravityStrength = 1f; // How strong gravity should be (default 1)

    // This function is called when another 2D collider enters the trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object entering the trigger is the player (or has a specific tag)
        if (other.CompareTag("Char4"))
        {
            // Get the Rigidbody2D component of the player
            Rigidbody2D playerRb = other.GetComponent<Rigidbody2D>();

            // If the player has a Rigidbody2D and gravity isn't already on
            if (playerRb != null && playerRb.gravityScale == 0)
            {
                playerRb.gravityScale = gravityStrength; // Turn gravity on
                Debug.Log("Gravity Activated for Player!"); // Optional: for testing
            }
        }
    }
}

