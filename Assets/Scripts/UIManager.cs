using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static UIManager instance;
    private int current_life;

    private PlayerHealth playerHealth;
    
    public Text health, pistol_ammo, smg_ammo;
    public Slider slider;

    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }

        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        health.text = playerHealth.health.ToString();
        slider.value = playerHealth.health;
        pistol_ammo.text = AmmoManager.instance.ammoPlayer[0].ToString();
        smg_ammo.text = AmmoManager.instance.ammoPlayer[1].ToString();
    }
}
