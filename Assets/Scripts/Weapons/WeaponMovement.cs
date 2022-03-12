using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMovement : MonoBehaviour
{
    public float radious = 0.8f;
    public GameObject gunHolder;
    Vector3 posWeapon;
    private bool isFacingRight;

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
            isFacingRight = true;
        }

        else if ((mousePos.x < PlayerPos.x && mousePos.y > PlayerPos.y) || (mousePos.x < PlayerPos.x && mousePos.y < PlayerPos.y))
        {
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
        Vector2 centerPosition = Vector2.zero;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float distance = Vector3.Distance(mousePos, centerPosition);

        if (distance > radious)
        {
            var norm = mousePos.normalized;
            posWeapon.x = norm.x * radious + gunHolder.transform.position.x;
            posWeapon.y = norm.y * radious + gunHolder.transform.position.y;

            transform.position = posWeapon;
        }
    }

    private void rotateWeaponAsMouse()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 tempPos = transform.position;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - tempPos) * Quaternion.Euler(0, 0, 90);

    }
}
