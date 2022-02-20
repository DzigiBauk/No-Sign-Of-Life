using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSign : MonoBehaviour
{
    public enum Type
    {
        Freeze,
        Healing
    }

    public Type signType;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Player ply = collision.GetComponent<Player>();

            if (signType == Type.Freeze) ply.hasFreeze = true;
            if (signType == Type.Healing) ply.hasHeal = true;

            Destroy(this.gameObject);
        }
    }
}
