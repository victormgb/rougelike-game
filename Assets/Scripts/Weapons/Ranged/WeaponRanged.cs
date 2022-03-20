using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRanged : MonoBehaviour
{
    public float speedBullet;
    public bool isAutomatic;
    public AmmoType bulletType;
    public bool portatorIsEnemy = false;

    // Enemy Controllers
    BulletController bulletEnemyController;

    // Start is called before the first frame update
    void Start()
    {
        GameObject parent = transform.parent.gameObject;
        if(parent.tag == "Enemy")
        {
            portatorIsEnemy = true;
        }
        bulletEnemyController = GetComponent<BulletController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire()
    {
        if (portatorIsEnemy)
        {
            FireByEnemy();
            return;
        }

        FireByPlayer();
    }

    private void FireByPlayer()
    {
        if (bulletType == AmmoType.bullet)
        {
            if (AmmoManager.instance.ammoPlayer[WeaponController.instance.currentWeaponIndex] > 0)
            {
                AmmoManager.instance.ammoPlayer[WeaponController.instance.currentWeaponIndex]--;
                WeaponController.instance.currentWeapon.GetComponent<AudioSource>().Play();
                GameObject bullet = Instantiate(AmmoManager.instance.bullets[0]);
                bullet.transform.position = transform.position;
            }

        }
    }

    private void FireByEnemy()
    {
        bulletEnemyController.fire();
    }
}
