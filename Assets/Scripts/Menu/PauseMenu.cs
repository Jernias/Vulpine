using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool isPlaying = false;
    public GameObject pauseMenu, restartMenu, mainMenu, gameInfos;
    public Character character;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (isPlaying)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }

        if (character.isDead)
        {
            gameInfos.SetActive(false);
            restartMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPlaying = true;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        isPlaying = false;

    }

    public void LoadMainMenu()
    {
        gameInfos.SetActive(false);
        Time.timeScale = 0f;
        mainMenu.SetActive(true);
    }


}
