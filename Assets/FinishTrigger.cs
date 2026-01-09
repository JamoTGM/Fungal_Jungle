using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishTrigger : MonoBehaviour
{
    public GameObject levelCompleteUI;

    [Header("Key Settings")]
    public string keyTag = "Key";
    public bool keyCollected = false;

    void Awake()
    {
        Time.timeScale = 1f;

        if (levelCompleteUI != null)
            levelCompleteUI.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("WindAffectable")) return;

        PlayerPickup pickup = collision.GetComponent<PlayerPickup>();
        if (pickup == null)
        {
            Debug.Log("WindAffectable object missing PlayerPickup script!");
            return;
        }

        if (!pickup.HasAllKeys())
        {
            Debug.Log("Exit locked - need more water! Collected: " + pickup.keysCollected);
            return;
        }

        CompleteLevel();
    }



    void CompleteLevel()
    {
        levelCompleteUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RetryLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        Time.timeScale = 1f;
        Application.Quit();
        Debug.Log("Exit pressed");
    }

}

