using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController 
{
    private Animator playerAnimator;

    public PlayerAnimationController(Animator playerAnimator)
    {
        this.playerAnimator = playerAnimator;
    }

    public void StartJumpAnimation()
    {
        playerAnimator.SetBool("IsJumping", true);
    }

    public void StartIdleAnimation()
    {
        playerAnimator.SetBool("IsJumping", false);
    }
}
