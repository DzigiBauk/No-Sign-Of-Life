using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float health;
    public float speed;
    public int killCount;

    public List<WeaponItem> inventory;
    public WeaponItem currWeapon;

    public bool hasFreeze;
    public bool hasHeal;

    public Text hpTxt;
    public Canvas gameOver;

    public void Start()
    {
        if (inventory[0]) currWeapon = inventory[0];

        foreach (WeaponItem x in inventory)
        {
            x.disableSprite();
        }


        currWeapon.enableSprite();
        gameOver.enabled = false;
    }

    public void Update()
    {
        hpTxt.text = "HP: " + health;
        if(health < 1)
        {
            Destroy(this.gameObject);
            Time.timeScale = 0;
            gameOver.enabled = true;
        }
    }

    public float getSpeed()
    {
        return speed; 
    }

    public void setWeapon(int id)
    {
        currWeapon.disableSprite();

        currWeapon = inventory[id];

        currWeapon.enableSprite();
    }
}
