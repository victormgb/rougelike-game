using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject[] weapons = new GameObject[2];
    public GameObject player;
    public int currentWeaponIndex;
    private GameObject currentWeapon;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }

    private void FixedUpdate()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        currentWeaponIndex = 0;
        renderWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            swapWeapon();
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }

    void renderWeapon()
    {
        currentWeapon = Instantiate(weapons[currentWeaponIndex]);
        currentWeapon.transform.parent = transform;
        //Vector3 zero = Vector3.zero;
        //zero.z = -1;
        currentWeapon.transform.position = transform.position;
        currentWeapon.GetComponent<WeaponMovement>().gunHolder = player;
        
    }

    void swapWeapon()
    {
        if(currentWeaponIndex > 0)
        {
            currentWeaponIndex = 0;
        } else
        {
            currentWeaponIndex++;
        }
        clearChildren();
        renderWeapon();
    }

    void clearChildren()
    {
        Transform child = transform.GetChild(0);
        if (child) {
            Destroy(child.gameObject);
        }
        
    }

    void Fire()
    {
        // We need to see first if the weapon is ranged or melee in Order to see what component use
       //currentWeapon<Weapon>
       
    }
}
