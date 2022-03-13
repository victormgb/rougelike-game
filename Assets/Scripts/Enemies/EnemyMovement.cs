using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    private float waitTime;
    public float startWaitTime;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    //private Transform moveSpot;
    private Vector2 moveSpot;
    private Vector2 vectorPosition;
    private bool decisionTime;

    

    

    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;
        vectorPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        moveSpot = new Vector2((transform.position.x + vectorPosition.x), (transform.position.y + vectorPosition.y));
        decisionTime = true;
    }


    private void Update()
    {

        if (Random.Range(0, 2) == 0)
        {
            Debug.Log("moving");
            moveToOtherPosition();
        } else
        {
            Debug.Log("Attacking");
            attack();
        }
            
        
    }

    void moveToOtherPosition()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpot, speed * Time.deltaTime);
        
        if (Vector2.Distance(transform.position, moveSpot) < 0.2f)
        {
            if (waitTime <= 0)
            {
                vectorPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                moveSpot = new Vector2((transform.position.x + vectorPosition.x), (transform.position.y + vectorPosition.y));
                waitTime = startWaitTime;
                //decisionTime = true;
                
            }
            else
            {
                waitTime -= Time.deltaTime;
                //decisionTime = false;
            }
        }
    }

    void attack()
    {
        if (waitTime <= 0)
        {
            //decisionTime = true;

        }
        else
        {
            waitTime -= Time.deltaTime;
            //decisionTime = false;
        }
    }
}
