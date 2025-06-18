using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimatorController : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SetMove(bool isMoving)
    {
        animator.SetBool("isMoving", isMoving);
    }

    public void TriggerHurt()
    {
        animator.SetTrigger("isHurt");
    }

    public void TriggerDeath()
    {
        animator.SetTrigger("isDead");
    }
    public void ResetToIdle()
    {
        if (animator == null) return;

        animator.Rebind();                
        animator.Update(0f);              
        animator.Play("PlayerIdle");
        animator.SetTrigger("isRevive");
        animator.ResetTrigger("isRevive");
    }
}
