using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    private float speed = 16f;
    public GameObject bullet_impact;

    // Start is called before the first frame update
    void OnEnable()
    {
        rb.velocity = speed * transform.right;
        StartCoroutine(Deactivate());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Frog frog = collision.GetComponent<Frog>();
        Eagle eagle = collision.GetComponent<Eagle>();

        if (frog != null)
        {
            frog.TakeDamage(25);

        }

        if(eagle != null)
        {
            eagle.Die();
        }

        Instantiate(bullet_impact, transform.position, transform.rotation);

        gameObject.SetActive(false);

        Destroy(GameObject.FindGameObjectWithTag("Impact"), 0.1f);
    }

    private IEnumerator Deactivate()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
        
    }
}
