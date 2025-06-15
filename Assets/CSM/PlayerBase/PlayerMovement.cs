using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(PlayerStatus))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerStatus status;
    private Vector2 moveInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        status = GetComponent<PlayerStatus>();
    }

    private void Update()
    {
        moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
    }

    private void FixedUpdate()
    {
        float moveSpeed = status != null ? status.MoveSpeed : 5f;
        rb.velocity = moveInput * moveSpeed;
    }
}
