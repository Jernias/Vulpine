using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    ObjectPooler objectPooler;
    //FrogPooler frogPooler;
    GameObject frog;
    GameObject eagle;
    public Character character;
    public Score score;

    private int int_score = 0, random_number = 0, random_counter1=0, counter=0;
    public float speed=6f, timeScaling=0f, time;


    Vector2 vector_frog= new Vector2(11.22f,-2.3f);
    Vector2 vector_eagle = new Vector2(11.22f, 0.1f);

    void Start()
    {
        int_score = score.score;

        objectPooler = ObjectPooler.Instance;

        StartCoroutine(spawner());
    }

    void Update()
    {
        int_score = score.score;      
    }

    IEnumerator spawner()
    {
        while (!character.isDead)
        {
            random_number = Random.Range(1, 3);
            if (random_counter1 == random_number)
            {
                counter++;
            }
            else
            {
                counter = 0;
            }

            if(counter==2 && random_number == 1)
            {
                random_number = 2;
                counter = 0;
            }
            else if(counter==2 && random_number==2)
            {
                random_number = 1;
                counter = 0;
            }

            random_counter1 = random_number;

            if (timeScaling <  score.timeScale && speed<12)
            {
                timeScaling = score.timeScale;
                speed += score.timeScale*0.66f;
            }


            if (3 - score.timeScale * 0.35f > .89f)
            {
                time = 3 - score.timeScale * 0.35f;
            }

            yield return new WaitForSeconds(time);

            switch (random_number)
            {
                case 1:
                    frog = objectPooler.SpawnObject("frog", vector_frog, Quaternion.identity);
                    break;
                case 2:
                    switch (int_score)
                    {
                        case var expression when int_score<100:
                            frog = objectPooler.SpawnObject("frog", vector_frog, Quaternion.identity);
                            break;
                        default:
                            eagle = objectPooler.SpawnObject("eagle", vector_eagle, Quaternion.identity);
                            break;
                    }
                    break;
            }
        }
    }
}
