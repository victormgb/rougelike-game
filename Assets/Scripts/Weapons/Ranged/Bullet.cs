using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private float bulletSpeed;
    private GameObject currentWeapon;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        currentWeapon = WeaponController.instance.currentWeapon;

        bulletSpeed = currentWeapon.GetComponent<WeaponRanged>().speedBullet;

        //transform.rotation = currentWeapon.transform.rotation * Quaternion.Euler(0, 0, -90f);
        transform.rotation = currentWeapon.transform.rotation;

        // TO DO programar disparo de enemigo


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {

        rb.velocity = transform.right * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().receiveDamage();
            Destroy(gameObject);
        }
    }
}
