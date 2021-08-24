using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    public Character character;

    public Text health_text;

    public int health = 5;
    private int extraHealth;

    // Start is called before the first frame update
    void Start()
    {
        health_text.text = "Health: "+health.ToString();
    }

    private void Update()
    {
        if (extraHealth < Score.bonusHealth)
        {
            extraHealth++;
            health++;
            health_text.text = "Health: " + health.ToString();
        }
    }
    public void UpdateHealth()
    {
        if(health == 0)
        {
            character.isDead = true;
        }
        else
        {
            health--;
            health_text.text = "Health: "+health.ToString();
        }
        

    }
}
