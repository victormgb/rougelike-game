using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AmmoType
{
    bullet,
    bolt,
    energy
}

public class AmmoManager : MonoBehaviour
{
    public static AmmoManager instance;
    public GameObject[] bullets;

    public int[] ammoPlayer = new int[3];
    // 0 bullet
    // 1 bolt
    // 2 energy

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        ammoPlayer[0] = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
