using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampolineBehaviour : MonoBehaviour
{
    [SerializeField] private float bounciness;
    private CharacterController2D playerController;
    private Vector2 velocityIn;

    private void Bounce(Rigidbody2D objectToBounce)
    {
        velocityIn = objectToBounce.velocity;
        playerController = objectToBounce.gameObject.GetComponent<CharacterController2D>();

        if (playerController)
        {
            velocityIn.y = Mathf.Sign(velocityIn.y) * playerController.GetJumpSpeed() * -1f * bounciness;
        }
        else
        {
            velocityIn.y *= -1f * bounciness;
        }     
        
        objectToBounce.velocity = velocityIn;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Bounce(collision.attachedRigidbody);
    }





}
