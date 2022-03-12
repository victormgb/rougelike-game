using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BulletType
{
    bullet,
    bolt,
    energy
}

public class BulletManager : MonoBehaviour
{
    public static BulletManager instance;
    public GameObject[] bullets;
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
