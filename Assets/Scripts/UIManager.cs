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

    public Canvas GameOverCanvas;

    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        GameOverCanvas.enabled = false;
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHealth.health <= 0)
        {
            health.text = "0";
            GameOverCanvas.enabled = true;
            slider.value = 0;
        } else
        {
            health.text = playerHealth.health.ToString();
        }
        
        slider.value = playerHealth.health;
        pistol_ammo.text = AmmoManager.instance.ammoPlayer[0].ToString();
        smg_ammo.text = AmmoManager.instance.ammoPlayer[1].ToString();
    }
}
