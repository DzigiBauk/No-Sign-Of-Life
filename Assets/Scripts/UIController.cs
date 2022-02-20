using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Player ply;

    public Image healIcon;
    public Image freezeIcon;

    public void Update()
    {
        if (ply.hasFreeze)
        {
            freezeIcon.enabled = true;
        } else { freezeIcon.enabled = false; }

        if (ply.hasHeal)
        {
            healIcon.enabled = true;
        } else { healIcon.enabled = false; }
    }
}
