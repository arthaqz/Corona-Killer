using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const string HORIZONTAL_AXIS = "Horizontal";
    private const float ZERO = 0f;
    
    private Rigidbody2D rb;

    [Header("Movement")]    
    public float moveSpeed;
    private float horizontal, vertical;
    
    [Header("Jumping")]
    public float jumpForce;
    [SerializeField] private Transform[] feet;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private LayerMask groundLayer;
    private bool isGrounded;
    
    [Header("Extra Jumping")]
    private bool canDoubleJump = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        MoveInput();
    }

    private void Update()
    {
        Jump();
    }

    private void MoveInput()
    {
        horizontal = Input.GetAxisRaw(HORIZONTAL_AXIS);
        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);;
    }

    

#region Jumping
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IsGrounded())
            {
                canDoubleJump = true;
                PerformJump();
            }
            else if (canDoubleJump)
            {
                canDoubleJump = false;
                PerformJump();
            }
        }
    }
   
    private void PerformJump()
    {
        rb.velocity = Vector2.up * jumpForce;
    }

    private bool IsGrounded()
    {
        return feet.Any(foot => Physics2D.OverlapCircle(foot.position, groundCheckRadius, groundLayer));
    }

    private void OnDrawGizmos()
    {
        foreach (var f in feet)
        {
            Gizmos.DrawSphere(f.position, groundCheckRadius);
        }
    }

#endregion

}
