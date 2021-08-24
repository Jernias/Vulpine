using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;

    public GameObject bullet;
    public float bulletnumber = 15;
    public Text bullet_text;
    ObjectPooler objectPooler;

    private float fireRate = 0.4f;
    private float nextFire = 0.0f;
    private float screenWidth;
    private bool isShoot;
    private int extraBullet=0;

    // Start is called before the first frame update
    private void Start()
    {
        bullet_text.text = "Bullet: " + bulletnumber.ToString();

        objectPooler = ObjectPooler.Instance;

        screenWidth = Screen.width;
    }

    // Update is called once per frame
    void Update()
    {
        isShoot = false;

        if (extraBullet< Score.bonusBullet)
        {
            bulletnumber++;
            extraBullet++;
            bullet_text.text = "Bullet: " + bulletnumber.ToString();
        }

        if (0 < Input.touchCount && Input.touches[0].position.x > screenWidth / 2)
        {
            isShoot = true;
        }
        if ((Input.GetButtonDown("YigitFire") || isShoot)&& Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Shoot();
        }
    }

    private void Shoot()
    {
        if (bulletnumber > 0)
        {
            objectPooler.SpawnObject("bullet", firePoint.transform.position, Quaternion.identity);

            bulletnumber--;
            bullet_text.text = "Bullet: " + bulletnumber.ToString();

        }
    }
}
