using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject GameInfos, mainMenu;

    private static bool isStarted;

    void Start()
    {
        if (!isStarted)
        {
            mainMenu.SetActive(true);
            GameInfos.SetActive(false);
            Time.timeScale = 0f;
        }
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Main");
        Time.timeScale = 1f;
        GameInfos.SetActive(true);
        isStarted = true;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
