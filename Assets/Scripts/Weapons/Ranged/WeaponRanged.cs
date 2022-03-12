using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRanged : MonoBehaviour
{
    public float speedBullet;
    public bool isAutomatic;
    public BulletType bulletType;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Fire()
    {
        if (bulletType == BulletType.bullet)
        {
            //Instantiate(weapons[currentWeaponIndex]);
            GameObject bullet = Instantiate(BulletManager.instance.bullets[0]);
            bullet.transform.position = transform.position;   
        }
    }
}
