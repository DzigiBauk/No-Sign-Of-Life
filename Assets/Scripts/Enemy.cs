using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Player ply;
    public Animator anim;
    public float knockbackPower;

    Rigidbody2D rb;

    public int health;
    public float speed;

    Vector3 previousPos;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        ply = FindObjectOfType<Player>();
        rb = GetComponent<Rigidbody2D>();
        previousPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = ply.transform.position;
        Vector3 enemyPos = this.transform.position;

        transform.position = Vector3.Lerp(enemyPos, playerPos, speed*Time.deltaTime);

        if (previousPos.x > transform.position.x)
        {
            anim.SetInteger("walk_direction", 3);
        } 

        if (previousPos.x < transform.position.x)
        {
            anim.SetInteger("walk_direction", 4);
        }

        previousPos = transform.position;
    }

    public void Hurt()
    {
        anim.SetTrigger("hurt");

        health -= ply.currWeapon.damage;
        if(health < 1)
        {
            ply.killCount += 1;
            Destroy(this.gameObject);
        }

        float timer = 0;

        while (5 > timer)
        {
            timer += Time.deltaTime;
            Vector2 direction = (this.transform.position - ply.transform.position).normalized;
            rb.AddForce(direction * knockbackPower);
        }
    }
}
