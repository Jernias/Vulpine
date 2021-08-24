using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle : MonoBehaviour
{
    public Rigidbody2D rb;
    public Spawner speedVariable;
    public GameObject speedScale;

    private float speed;
    private void Awake()
    {
        speedVariable = GameObject.Find("GameManagement").GetComponent<Spawner>();
    }
    void OnEnable()
    {
        speed = speedVariable.speed * 1.2f;
        rb.velocity = -speed * transform.right;
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (rb.transform.position.x < -12f)
        {
            gameObject.SetActive(false);
        }
    }
}
