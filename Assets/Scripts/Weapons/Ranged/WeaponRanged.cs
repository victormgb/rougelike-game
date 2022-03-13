using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRanged : MonoBehaviour
{
    public float speedBullet;
    public bool isAutomatic;
    public AmmoType bulletType;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire()
    {
        if (bulletType == AmmoType.bullet)
        {
            if(AmmoManager.instance.ammoPlayer[0] > 0)
            {
                AmmoManager.instance.ammoPlayer[0]--;
                GameObject bullet = Instantiate(AmmoManager.instance.bullets[0]);
                bullet.transform.position = transform.position;
            }

        }
    }
}
