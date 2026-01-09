using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    public bool keyCollected = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Key"))
        {
            keyCollected = true;
            collision.gameObject.SetActive(false);
            Debug.Log("Key picked up by player");
        }
    }
}

