using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttack : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            //Hit
            Enemy hitZombie = collision.GetComponent<Enemy>();
            hitZombie.Hurt();

            //Random Audio
            int rndm = Random.Range(1, 6);
            FindObjectOfType<AudioManager>().Play("hit-" + rndm);
        }
    }
}
