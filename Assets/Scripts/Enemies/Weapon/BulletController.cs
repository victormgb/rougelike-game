using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameObject bulletObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void fire()
    {
        
        GameObject newBullet = Instantiate(bulletObject);
        newBullet.transform.position = transform.position;
        newBullet.transform.rotation = transform.rotation;
        
    }
}
