using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    public int damage;

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Player ply = collision.GetComponent<Player>();

            ply.health -= Time.deltaTime * damage;

            Debug.Log("DMG?");
        }
    }
}
