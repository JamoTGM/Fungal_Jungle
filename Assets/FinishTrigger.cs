using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishTrigger : MonoBehaviour
{
    public GameObject levelCompleteUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("WindAffectable"))
        {
            CompleteLevel();
        }
    }

    void CompleteLevel()
    {
        levelCompleteUI.SetActive(true);
        Time.timeScale = 0f;
    }

    // Retry Button
    public void RetryLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Exit Button
    public void ExitGame()
    {
        Time.timeScale = 1f;
        Application.Quit();
        Debug.Log("Exit button pressed");
    }
}
