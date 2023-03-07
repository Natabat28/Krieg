using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    public GameObject pauseMenuUI;
    public GameObject startMenu;

    private void Start()
    {
        Time.timeScale = 0f;
    }

    public void Launch()
    {
        startMenu.SetActive(false);
        pauseMenuUI.SetActive(true);
        gameManager.isGameStarted = true;
        gameManager.isGamePaused = false;
        gameManager.isGameRunning = true;
        Time.timeScale = 1f;
    }


    public void QuitGame()
    {
        Application.Quit();
    }

    public void hardReset()
    {
        startMenu.SetActive(true);
        pauseMenuUI.SetActive(false);
        gameManager.isGameStarted = false;
        gameManager.isGamePaused = true;
        gameManager.isGameRunning = false;
        Time.timeScale = 0f;
    }


}
