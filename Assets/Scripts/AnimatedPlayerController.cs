using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Animator))]
public class AnimatedPlayerController : PlayerController
{
    const string animatorWalkKey = "walking";
    const string animatorJumpKey = "jump";
    const string animatorHitKey = "hit";
    const string animatorDieKey = "die";
    const string animatorFreeFallKey = "falling";

    const string jumpAnimationName = "jump";
    const string hurtAnimationName = "hit";

    Animator animator;
    Animator Animator { 
        get 
        { 
            if(animator == null)
                animator = GetComponent<Animator>();
            return animator;
        } 
    }


    protected override void OnEnable()
    {
        RPGRuntimeInputHelper.WalkKeysReleased += () => ToggleWalking(false);
        base.OnEnable();
    }

    protected override void OnDisable()
    {
        RPGRuntimeInputHelper.WalkKeysReleased -= () => ToggleWalking(false);
        base.OnDisable();
    }

    protected override void PlayerMoveWithCam(float horizontal_axis, float vertical_axis)
    {
        ToggleWalking(canMove);
        base.PlayerMoveWithCam(horizontal_axis, vertical_axis);
    }

    bool walking;
    void ToggleWalking(bool walk)
    {
        if (walking != walk)
        {
            walking = walk;
            Animator.SetBool(animatorWalkKey, walk);
        }
    }

    bool IsJumping => Animator.GetCurrentAnimatorStateInfo(0).IsName(jumpAnimationName)|| Animator.IsInTransition(0);
    bool canJump = true;

    protected override void Jump()
    {
        if (canJump == false)
            return;

        if (IsJumping)
            return;

        Animator.SetTrigger(animatorJumpKey);
        canJump = false;

        StartCoroutine(IEJump());
        base.Jump();
    }
    IEnumerator IEJump()
    {

        while (IsJumping)
        {
            yield return null;
        }
     
        canJump = true;
    }

    float HurtAnimationDuration => 1.5f;

    protected override void Hurt()
    {
        Animator.SetTrigger(animatorHitKey);

        StartCoroutine(IEHurt());
        base.Hurt();
    }
    IEnumerator IEHurt()
    {
        yield return null;

        canMove = false;

        yield return new WaitForSeconds(HurtAnimationDuration);

        canMove = true;
    }

    protected override void Dead()
    {
        base.Dead();
        Animator.SetTrigger(animatorDieKey);
    }

    public override void FallToDeath()
    {
        base.Dead();
        Animator.SetTrigger(animatorFreeFallKey);
    }
}
