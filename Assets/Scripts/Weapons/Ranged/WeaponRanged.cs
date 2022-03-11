using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRanged : MonoBehaviour
{
    public float radious = 0.8f;
    //Vector3 centerPosition;
    public GameObject gunHolder;
    Vector3 posWeapon;


    private void Start()
    {
        posWeapon = transform.position;
    }


    private void Update()
    {
        //Debug.Log(gunHolder.transform.localPosition);

        //Vector2 centerPosition = gunHolder.transform.localPosition;
        Vector2 centerPosition = Vector2.zero;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(mousePos);
        float distance = Vector3.Distance(mousePos,centerPosition );

        if(distance > radious)
        {
            //Vector2 fromOriginObject = mousePos.normalized - centerPosition;
            //fromOriginObject *= radious / distance;
            //posWeapon.x = fromOriginObject.x;
            //posWeapon.y = fromOriginObject.y;
            //posWeapon.z = transform.position.z;
            var norm = mousePos.normalized;
            posWeapon.x = norm.x * radious + gunHolder.transform.position.x;
            posWeapon.y = norm.y * radious + gunHolder.transform.position.y;
            posWeapon.z = transform.position.z;

            transform.position = posWeapon;
        }



        
    }

    private void OnDrawGizmosSelected()
    {
        Vector2 centerPosition = gunHolder.transform.localPosition;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Gizmos.DrawRay(centerPosition,mousePos);
    }

    //private void Update()
    //{
    //    
    //    direction = mousePos - (Vector2)transform.position;



    //}


}
