using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartMenu : MonoBehaviour
{
    public GameObject mainMenu,restartMenu, GameInfos;
    public Character character;
    public Score score;
    public Text finalScore, highScore;
    public int highscore;

    private void OnEnable()
    {
        finalScore.text = "Your Score: "+score.score.ToString();

        highscore = score.score;

        if (highscore > PlayerPrefs.GetInt("highscore", 0))
        {
            PlayerPrefs.SetInt("highscore", highscore);
        }

        highScore.text = "Highscore: "+PlayerPrefs.GetInt("highscore", 0).ToString();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Main");
        character.isDead = false;
        Time.timeScale = 1f;
        GameInfos.SetActive(true);

    }
    public void MainMenu()
    {
        character.isDead = false;
        mainMenu.SetActive(true);
        restartMenu.SetActive(false);
    }


}
