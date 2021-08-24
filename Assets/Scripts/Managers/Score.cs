using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public Text text;
    public int score=0;
    public Character character;
    
    public int timeScale;
    public static int bonusBullet, bonusHealth;
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        text.text = "Score: "+score.ToString();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!character.isDead)
        {
            time = Time.timeSinceLevelLoad * 5;
            score = (int)time;
            text.text = "Score: " + score.ToString();

            timeScale = score / 50;
            bonusBullet = score / 150;
            bonusHealth = score / 500;

        }
    }
}
