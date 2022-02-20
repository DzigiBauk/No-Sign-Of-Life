using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator weaponAnimator;
    public Animator characterAnimator;

    private void Start()
    {

    }

    public void startSwing()
    {
        weaponAnimator.SetTrigger("Attack");
    }

    public void walkDirection(int x)
    {
        characterAnimator.SetInteger("walk_direction", x);
    }

    public void walkReset()
    {
        characterAnimator.SetInteger("walk_direction", 0);
    }

}
