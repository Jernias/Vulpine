using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSpeed : MonoBehaviour
{
    public Animator background, ground;
    public Spawner speedVariable;


    // Update is called once per frame
    void Update()
    {
        if (speedVariable.speed < 12)
        {
            background.speed = speedVariable.speed/6;
            ground.speed = speedVariable.speed/6;

        }
    }
}
