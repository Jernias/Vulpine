using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{


    Rigidbody2D rb;
    public Health health;
    public Animator animator;
    public Spawner speed_var; 

    public float speed;

    public bool isDead=false;
    bool isGrounded;
    bool hurt = false;

    private float screenWidth, screenHeight;
    private bool isJumped;

    [SerializeField]
    Transform GroundCheck;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        screenWidth = Screen.width;
        screenHeight = Screen.height;
    }


    private void FixedUpdate()
    {
        //Check if player is grounded
        if (Physics2D.Linecast(transform.position, GroundCheck.position, 1 << LayerMask.NameToLayer("Ground")))
        {
            isGrounded = true;

        }
        else
        {
            isGrounded = false;
        }

        //Player Movement if its not dead
        if (!isDead && !hurt)
        {
            isJumped = false;

            if (0 < Input.touchCount && Input.touches[0].position.x < screenWidth / 2 && Input.touches[0].position.y < screenHeight* 2/3)
            {
                isJumped = true;
            }
            if ((Input.GetKey("space") || Input.GetKey("w") || isJumped) && isGrounded)
            {
                animator.speed = 1;
                rb.velocity = new Vector2(rb.velocity.x, speed*1.15f);
                animator.SetBool("Jump", true);
            }
            else if(isGrounded==true)
            {
                animator.speed = speed_var.speed / 6;
                animator.SetBool("Jump", false);
            }
            else if(rb.transform.position.y>-1.47f)
            {
                animator.SetBool("Jump", false);
            }
        }

        if (health.health == 0)
        {
            isDead = true;
            Time.timeScale = 0f;

        }
    }

    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            hurt = true;
            animator.SetBool("Hurt", hurt);

            collision.gameObject.SetActive(false);
            health.UpdateHealth();

            yield return new WaitForSeconds(0.5f);
            hurt = false;
            animator.SetBool("Hurt", hurt);
        }
    }

    public void isHurt()
    {
        animator.SetBool("Hurt", false);
    }

}

