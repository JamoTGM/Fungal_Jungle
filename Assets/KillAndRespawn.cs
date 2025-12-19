using UnityEngine;

public class KillAndRespawn : MonoBehaviour
{
    public Transform respawnPoint;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Char4"))
        {
            other.transform.position = respawnPoint.position;
        }
    }
}
