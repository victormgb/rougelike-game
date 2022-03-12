using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    Ranged, 
    Melee
}

public class Weapon : MonoBehaviour
{
    public WeaponType type;
    private WeaponRanged weaponRanged;


    //private WeaponRanged 

    // Start is called before the first frame update
    void Start()
    {
        if (type == WeaponType.Ranged) {
            weaponRanged = GetComponent<WeaponRanged>();
        } else
        {
            weaponRanged = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
            
    }
}
