using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    public int keysCollected = 0;  // Number of keys the player has
    public int keysNeeded = 2;     // Total keys required to unlock exit

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Key"))
        {
            keysCollected++;
            collision.gameObject.SetActive(false);
            Debug.Log("Key collected! Total keys: " + keysCollected);
        }
    }

    public bool HasAllKeys()
    {
        return keysCollected >= keysNeeded;
    }
}

