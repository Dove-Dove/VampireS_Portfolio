using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private Rigidbody2D rigidbody2D;
    private Vector2 moveInput;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        moveInput = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical")).normalized;
    }
    private void FixedUpdate()
    {
        rigidbody2D.velocity = moveInput * speed;
    }
}
