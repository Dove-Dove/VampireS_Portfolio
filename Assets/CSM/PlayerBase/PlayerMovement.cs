using UnityEngine;
using UnityEngine.Windows;

[RequireComponent(typeof(Rigidbody2D), typeof(PlayerStatus))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerStatus status;
    private Vector2 moveInput;
    private PlayerAnimatorController anim;
    private SpriteRenderer sr;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        status = GetComponent<PlayerStatus>();
        anim = GetComponent<PlayerAnimatorController>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        moveInput = new Vector2( UnityEngine.Input.GetAxis("Horizontal"), UnityEngine.Input.GetAxis("Vertical")).normalized;
        anim?.SetMove(moveInput.sqrMagnitude > 0.01f);
        if (moveInput.x != 0)
            sr.flipX = moveInput.x < 0;
    }

    private void FixedUpdate()
    {
        float moveSpeed = status != null ? status.MoveSpeed : 5f;
        rb.velocity = moveInput * moveSpeed;
    }
}
