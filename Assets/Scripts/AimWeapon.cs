using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimWeapon : MonoBehaviour
{
    Transform weapon;

    private void Start()
    {
        weapon = transform.Find("Weapon");
    }

    private void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(weapon.position);

        Vector2 offset = new Vector2(mousePos.x - screenPoint.x, mousePos.y - screenPoint.y);

        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;

        Vector3 localScale = weapon.localScale;
        if(angle > 90 || angle < -90)
        {
            if (localScale.y > 0) localScale.y = -localScale.y;

        } else
        {
            if (localScale.y < 0) localScale.y = -localScale.y;
        }

        weapon.localScale = localScale;

        weapon.rotation = Quaternion.Euler(0, 0, angle);

    }
}
