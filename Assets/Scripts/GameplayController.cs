using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour
{
    [SerializeField] private GameObject gameplayButtons, pauseScreen, gameOverScreen;
    public static bool isDead;

    private void Awake()
    {
        isDead = false;
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (isDead)
        {
            StopGame();
        }
    }

    private void SwitchPause(float timeScale, bool gameplayButtonActive, bool pauseScreenActive)
    {
        Time.timeScale = timeScale;
        gameplayButtons.SetActive(gameplayButtonActive);
        pauseScreen.SetActive(pauseScreenActive);
    }

    public void PauseGame()
    {
        SwitchPause(0, false, true);
    }

    public void ContinueGame()
    {
        SwitchPause(1, true, false);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    private void StopGame()
    {
        Time.timeScale = 0;
        gameplayButtons.SetActive(false);
        gameOverScreen.SetActive(true);
    }
}
