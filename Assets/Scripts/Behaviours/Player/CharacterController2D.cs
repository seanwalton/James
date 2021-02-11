using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour
{

    [SerializeField] private float runSpeed;

    private Rigidbody2D rigidbody;
    private Vector2 myVelocity;
    private Vector2 currentInputDirection;
    
    private void Awake()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move(currentInputDirection);
    }

    private void Move(Vector2 direction)
    {
        myVelocity = rigidbody.velocity;
        myVelocity.x = direction.x * runSpeed;
        rigidbody.velocity = myVelocity;
    }

    public void OnJump(InputAction.CallbackContext input)
    {
        Debug.Log(input);
    }

    public void OnMove(InputAction.CallbackContext input)
    {
        currentInputDirection = input.ReadValue<Vector2>();
    }
}
