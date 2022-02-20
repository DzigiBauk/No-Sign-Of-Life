using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;
    Player ply;

    public GameObject healSign;
    public GameObject freezeSign;

    public AnimationController anim;

    float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ply = GetComponent<Player>();

        speed = ply.getSpeed();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // === MOVEMENT ===
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = (new Vector2(-speed, 0));
            anim.walkDirection(3);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = (new Vector2(speed, 0));
            anim.walkDirection(4);
        }

        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = (new Vector2(0, speed));
            anim.walkDirection(2);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = (new Vector2(0, -speed));
            anim.walkDirection(1);
        }

        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            anim.walkReset();
        }
    }

    private void Update()
    {
        // === SWING ATTACK ===
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            anim.startSwing();
        }

        // === SET WEAPON ===
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ply.setWeapon(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && ply.killCount >= 5)
        {
            ply.setWeapon(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && ply.killCount >= 10)
        {
            ply.setWeapon(2);
        }

        // === PLACABLE SIGNS ===

        if (Input.GetKeyDown(KeyCode.E) && ply.hasHeal)
        {
            GameObject newSign = Instantiate(healSign);
            newSign.transform.position = this.transform.position;
            ply.hasHeal = false;
        }

        if (Input.GetKeyDown(KeyCode.Q) && ply.hasFreeze)
        {
            GameObject newSign = Instantiate(freezeSign);
            newSign.transform.position = this.transform.position;
            ply.hasFreeze = false;
        }
    }
}
