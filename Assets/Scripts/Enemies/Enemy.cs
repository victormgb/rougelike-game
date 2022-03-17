using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float startWaitTime;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    // Movement Attributes
    private Vector2 moveSpot;
    private Vector2 vectorPosition;
    
    //Att attributes
    public float rangeToAttack;
    private GameObject player;
    public Animator animator;

    // Ranged Att Attributes
    WeaponMovementEnemy weaponEnemyMovement;
    WeaponRanged weaponEnemy;


    // Start is called before the first frame update
    void Start()
    {

        vectorPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        moveSpot = new Vector2((transform.position.x + vectorPosition.x), (transform.position.y + vectorPosition.y));
        player = GameObject.Find("Player").gameObject;
        InvokeRepeating("randomActions", startWaitTime, startWaitTime);


        GameObject child = transform.GetChild(0).gameObject;
        weaponEnemyMovement = child.GetComponent<WeaponMovementEnemy>();
        weaponEnemy = child.GetComponent<WeaponRanged>();
    }

    void randomActions()
    {
        if (Random.Range(0, 2) == 0 || !playerClose())
        {
            moveToOtherPosition();
        }
        else
        {
            StartCoroutine(attack());
        }
    }


    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpot, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, moveSpot) > 0.2f)
        {
            animator.SetBool("isMoving", true);
        } else
        {
            animator.SetBool("isMoving", false);
        }
    }

    void moveToOtherPosition()
    {
        if (Vector2.Distance(transform.position, moveSpot) < 0.2f)
        {
            vectorPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            moveSpot = new Vector2((transform.position.x + vectorPosition.x), (transform.position.y + vectorPosition.y));
        }
    }

    IEnumerator attack()
    {
        weaponEnemyMovement.aim();
        yield return new WaitForSeconds(1f);
        weaponEnemy.Fire();

    }

    bool playerClose()
    {
        if (Vector2.Distance(transform.position, player.transform.position) < rangeToAttack){
            return true;
        }
        return false;
        
    }
}
