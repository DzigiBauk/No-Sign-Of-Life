using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponItem : MonoBehaviour
{
    public string name;
    public int damage;
   
    public void onHitEffect()
    {
        Debug.Log("Effect!");
    }

    public void enableSprite()
    {
        this.transform.gameObject.SetActive(true);
    }

    public void disableSprite()
    {
        this.transform.gameObject.SetActive(false);
    }
}
