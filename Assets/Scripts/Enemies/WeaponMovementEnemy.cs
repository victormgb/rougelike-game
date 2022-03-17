using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMovementEnemy : MonoBehaviour
{
    private GameObject player;

    public float radious = 0.5f;
    Vector3 posWeapon;
    private bool isFacingRight;

    public GameObject gunHolder;
    // Start is called before the first frame update
    void Start()
    {
        posWeapon = transform.position;
        isFacingRight = true;
        player = GameObject.Find("Player");
        

    }

    // Update is called once per frame
    void Update()
    {
        //translateWeaponInEnemy();
        //rotateWeapon();
    }

    public void aim()
    {
        translateWeaponInEnemy();
        rotateWeapon();
    }

    void translateWeaponInEnemy()
    {
        Vector2 centerPosition = Vector2.zero;
        Vector2 playerPos = player.transform.position;
        float distance = Vector3.Distance(playerPos, centerPosition);

        var norm = playerPos.normalized;

        posWeapon.x = norm.x * radious + gunHolder.transform.position.x;
        posWeapon.y = norm.y * radious + gunHolder.transform.position.y;

        transform.position = posWeapon;
        
    }

    void rotateWeapon()
    {
        Vector3 playerPos = player.transform.position;
        Vector3 tempPos = transform.position;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, playerPos - tempPos) * Quaternion.Euler(0, 0, 90);
    }

    //public void 
}
