using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameOverScreen gameOverScreen;
    //public PauseScreen pauseScreen;
    public int enemyDieCount = 0;
    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverScreen.Setup(enemyDieCount);
        Cursor.lockState = CursorLockMode.None;
    }

    public void Paused()
    {
        //PauseScreen.isPaused = true;
        Time.timeScale = 0;
        //pauseScreen.Setup();
    }

    public void RestartButton()
    {
        GameOverScreen.isOver = false;
        Time.timeScale = 1;
        SceneManager.LoadScene("Level 1");
    }

    public void ResumeButton()
    {
        Time.timeScale = 1;
        //PauseScreen.isPaused = false;
        //pauseScreen.Setup();
    }

    public void ExitButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
