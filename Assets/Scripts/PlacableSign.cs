using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacableSign : MonoBehaviour
{
    float duration = 5f;

    public float healingRate;
    public float freezeMultiplier;

    public List<Enemy> frozenEnemies;

    public enum Type
    {
        Healing,
        Freezing
    }

    public Type sign;

    public void Start()
    {
        Destroy(this.gameObject, duration);
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (sign == Type.Healing)
        {
            if (collision.tag == "Player")
            {
                Player ply = collision.GetComponent<Player>();
                if (ply.health < 20)
                {
                    ply.health += healingRate * Time.deltaTime;
                } 

                if (ply.health > 20)
                {
                    ply.health = 20;
                }
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (sign == Type.Freezing)
        {
            if (collision.tag == "Enemy")
            {
                Enemy zomb = collision.GetComponent<Enemy>();

                zomb.speed = zomb.speed / 5;
                frozenEnemies.Add(zomb);
            }
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (sign == Type.Freezing)
        {
            if (collision.tag == "Enemy")
            {
                Enemy zomb = collision.GetComponent<Enemy>();

                zomb.speed = zomb.speed * 5;
                frozenEnemies.Remove(zomb);
            }
        }
    }

    public void OnDestroy()
    {
        foreach(Enemy x in frozenEnemies)
        {
            x.speed *= 5;
        }
    }
}
