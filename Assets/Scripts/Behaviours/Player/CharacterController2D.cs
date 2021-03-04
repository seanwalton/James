using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour
{

    [SerializeField] private float runSpeed;
    [SerializeField] private float jumpSpeed;

    [SerializeField] private Transform groundCheckTr;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private LayerMask groundLayers;

    public UnityEvent OnJumpEvent;


    private Rigidbody2D rigidbody;
    private Vector2 myVelocity;
    private Vector2 currentInputDirection;
    private bool onGround;
    private int numColliders;
    private Collider2D[] colliders = new Collider2D[10];
    private bool facingRight;
    private Vector3 newScale;
    private Transform tr;


    public float GetJumpSpeed() => jumpSpeed;

    private void Awake()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        onGround = false;
        tr = transform;
        facingRight = tr.localScale.x == 1;
    }

    private void Update()
    {
        Move(currentInputDirection);
    }

    private void FixedUpdate()
    {
        GroundCheck();        
    }

    private void GroundCheck()
    {
        numColliders = Physics2D.OverlapCircleNonAlloc(groundCheckTr.position, groundCheckRadius, colliders, groundLayers);
        onGround = (numColliders > 0);
    }

    private void Move(Vector2 direction)
    {
        myVelocity = rigidbody.velocity;
        myVelocity.x = direction.x * runSpeed;
        rigidbody.velocity = myVelocity;
        CheckFacing();
    }


    private void CheckFacing()
    {
        if (facingRight && (currentInputDirection.x < 0f))
        {
            Flip();
        }
        else if (!facingRight && (currentInputDirection.x > 0f))
        {
            Flip();
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        newScale = tr.localScale;
        newScale.x *= -1f;
        tr.localScale = newScale;
    }

    private void PerformJump()
    {
        if (!onGround) return;
        OnJumpEvent?.Invoke();
        myVelocity = rigidbody.velocity;
        myVelocity.y = jumpSpeed;
        rigidbody.velocity = myVelocity;
    }

    public void OnJump(InputAction.CallbackContext input)
    {
        if (input.started) PerformJump();
    }

    public void OnMove(InputAction.CallbackContext input)
    {
        currentInputDirection = input.ReadValue<Vector2>();
    }
}
