using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMovement : MonoBehaviour
{
    public float radious = 0.8f;
    //Vector3 centerPosition;
    public GameObject gunHolder;
    Vector3 posWeapon;
    private bool isFacingRight;

    //public bool leftCuadrant = false;
    //public bool rightCuadrant = false;


    private void Start()
    {
        posWeapon = transform.position;
        isFacingRight = true;
    }


    private void Update()
    {

        translateWeaponInPlayer();
        rotateWeaponAsMouse();

    }

    private void FixedUpdate()
    {
        updatePlayerFacing();
    }

    private void updatePlayerFacing()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 PlayerPos = gunHolder.transform.position;



        if ((mousePos.x > PlayerPos.x && mousePos.y > PlayerPos.y) || (mousePos.x > PlayerPos.x && mousePos.y < PlayerPos.y))
        {
            //rightCuadrant = true;
            isFacingRight = true;
        }

        else if ((mousePos.x < PlayerPos.x && mousePos.y > PlayerPos.y) || (mousePos.x < PlayerPos.x && mousePos.y < PlayerPos.y))
        {
            //leftCuadrant = true;
            isFacingRight = false;
        }


        if (isFacingRight)
        {
            Vector3 theScale = transform.localScale;
            theScale.x = 1;
            theScale.y = 1;
            transform.localScale = theScale;

            Vector3 theScalePlayer = gunHolder.transform.localScale; ;
            theScalePlayer.x = 1;
            gunHolder.transform.localScale = theScalePlayer;


        }

        else if (!isFacingRight)
        {
            Vector3 theScale = transform.localScale;
            theScale.x = -1;
            theScale.y = -1;
            transform.localScale = theScale;

            Vector3 theScalePlayer = gunHolder.transform.localScale; ;
            theScalePlayer.x = -1;
            gunHolder.transform.localScale = theScalePlayer;

            isFacingRight = true;
        }

    }

    private void translateWeaponInPlayer()
    {
        //Debug.Log(gunHolder.transform.localPosition);

        //Vector2 centerPosition = gunHolder.transform.localPosition;
        Vector2 centerPosition = Vector2.zero;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float distance = Vector3.Distance(mousePos, centerPosition);

        if (distance > radious)
        {
            //Vector2 fromOriginObject = mousePos.normalized - centerPosition;
            //fromOriginObject *= radious / distance;
            //posWeapon.x = fromOriginObject.x;
            //posWeapon.y = fromOriginObject.y;
            //posWeapon.z = transform.position.z;
            var norm = mousePos.normalized;
            posWeapon.x = norm.x * radious + gunHolder.transform.position.x;
            posWeapon.y = norm.y * radious + gunHolder.transform.position.y;

            transform.position = posWeapon;
        }
    }

    private void rotateWeaponAsMouse()
    {
        //Debug.Log("pasa x aca");
        //float RotationSpeed = 5;
        //transform.Rotate((Input.GetAxis("Mouse X") * RotationSpeed * Time.deltaTime), (Input.GetAxis("Mouse Y") * RotationSpeed * Time.deltaTime), 0, Space.World);

        //transform.Rotate(180f,0);

        ////float angle = Mathf.Atan2(gunHolder.transform.position.x - norm.x, gunHolder.transform.position.y - norm.y) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, angle, 0), rotationSpeed * Time.deltaTime);



        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 tempPos = transform.position;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - tempPos) * Quaternion.Euler(0, 0, 90);

    }

    private void OnDrawGizmosSelected()
    {
        //Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Gizmos.DrawSphere(mousePos, 1);

        //Gizmos.DrawSphere(gunHolder.transform.position, 1);
    }
}
