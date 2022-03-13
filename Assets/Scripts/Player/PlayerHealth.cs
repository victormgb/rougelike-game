using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxLife;

    // Start is called before the first frame update
    void Start()
    {
        health = maxLife;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            int enemyDamage = -1;
            CollectHealth(enemyDamage);
        }

        // TO DO programar colision de disparo de Enemigo
        //if(collision.tag == "Bullet" && collision.gameObject.GetComponent<Bullet>().)
        //{

        //}
    }


    private void CollectHealth(int points)
    {
        this.health += points;

        if (this.health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Te has morido");
    }
}
