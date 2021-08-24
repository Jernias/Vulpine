using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    public Spawner speed_var;
    private float speed;
    public float health = 50f;

    private void Awake()
    {
        speed_var = GameObject.Find("GameManagement").GetComponent<Spawner>();
    }
    void OnEnable()
    {
        health = 50f;
        speed = speed_var.speed;

        rb.velocity = -speed * transform.right;
        animator.SetFloat("Speed", 1);
        
    }

    
    public void TakeDamage(int Damage)
    {
        health -= Damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        gameObject.SetActive(false);
        animator.SetFloat("Speed", -1);

    }

    void Update()
    {
        if (rb.transform.position.x < -12f)
        {
            gameObject.SetActive(false);
            animator.SetFloat("Speed", -1);
        }
    }
}

