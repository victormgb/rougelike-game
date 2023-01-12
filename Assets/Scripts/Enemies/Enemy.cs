using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

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

    // Detecting collision with walls
    public Tilemap obstacles;

    private const int MAX_LIFE = 3;
    private int current_life;

    // Start is called before the first frame update
    void Start()
    {

        current_life = MAX_LIFE;

        // Settear movimiento
        Vector2 vectorToMove = Vector2.zero;

        for (int i = 0; i < 100; i++)
        {
            vectorPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            vectorToMove = new Vector2((transform.position.x + vectorPosition.x), (transform.position.y + vectorPosition.y));
            Vector2 dir = (vectorToMove - (Vector2)transform.position);
            Vector3Int obstacleMapTile = obstacles.WorldToCell(vectorToMove);

            if (obstacles.GetTile(obstacleMapTile) == null)
            {
                break;
            }

        }

        moveSpot = vectorToMove;
        //-------



        player = GameObject.Find("Player").gameObject;
        InvokeRepeating("randomActions", startWaitTime, startWaitTime);


        GameObject child = transform.GetChild(0).gameObject;
        weaponEnemyMovement = child.GetComponent<WeaponMovementEnemy>();
        weaponEnemy = child.GetComponent<WeaponRanged>();
    }

    void randomActions()
    {
        if(current_life > 0)
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


    }


    private void Update()
    {
        if(current_life > 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, moveSpot, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, moveSpot) > 0.2f)
            {
                animator.SetBool("isMoving", true);
            }
            else
            {
                animator.SetBool("isMoving", false);
            }
        }

    }

    void moveToOtherPosition()
    {
        

        if (Vector2.Distance(transform.position, moveSpot) < 0.7f)
        {

            //vectorPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            //Vector2 vectorToMove = new Vector2((transform.position.x + vectorPosition.x), (transform.position.y + vectorPosition.y));
            //Vector2 dir = (vectorToMove - (Vector2)transform.position);
            //Vector3Int obstacleMapTile = obstacles.WorldToCell(vectorToMove);
            //Debug.DrawRay(transform.position, dir, Color.red, Mathf.Infinity);
            Vector2 vectorToMove = Vector2.zero;

            for (int i = 0; i < 100; i++)
            {
                vectorPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                vectorToMove = new Vector2((transform.position.x + vectorPosition.x), (transform.position.y + vectorPosition.y));
                Vector2 dir = (vectorToMove - (Vector2)transform.position);
                Vector3Int obstacleMapTile = obstacles.WorldToCell(vectorToMove);

                if(obstacles.GetTile(obstacleMapTile) == null)
                {
                    break;
                }

            }
  
            
            moveSpot = vectorToMove;
            
                //RaycastHit hit;
                //RaycastHit2D hit = Physics2D.Raycast(vectorToMove,Vector2.zero);
                //Debug.Log(hit.collider.gameObject.name);
                ////if(Physics.Raycast(transform.position, dir, out hit)){
                ////    print("ray just hit the gameobject: " + hit.collider.gameObject.name);
                ////}
                //Debug.Log(hit.collider.gameObject.name);
                //int layerMask = ~LayerMask.GetMask("Ground");
                //Debug.Log(Physics.Linecast(transform.position, vectorToMove, layerMask));




                
            
            
        }
    }

    IEnumerator attack()
    {
        weaponEnemyMovement.aim();
        yield return new WaitForSeconds(0.5f);
        weaponEnemy.Fire();

    }

    bool playerClose()
    {
        if (Vector2.Distance(transform.position, player.transform.position) < rangeToAttack){
            return true;
        }
        return false;
        
    }

    public void receiveDamage()
    {
        current_life--;

        //animacion de recibimiento de damage
        GetComponent<AudioSource>().Play();
        if (current_life <= 0)
        {
            die();
        } else
        {   
            animator.SetTrigger("damageReceived");
        }
    }

    private void die()
    {
        
        animator.SetBool("isDie", true);
    }

    void clearChildren()
    {
        Transform child = transform.GetChild(0);
        if (child)
        {
            child.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }

    }
}
