using System.Collections;
using System.Collections.Generic;
using TarodevController;
using Unity.VisualScripting;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    public PlayerController controller;
    [SerializeField] float bounceCiego = 20f;
    [SerializeField] float bounceDog = 20f;
    // Start is called before the first frame update
    void Start()
    {
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //animator.SetBool("jumpingThisFrame", true);
        if (collision.gameObject.CompareTag("Jugador"))
        {
            controller._currentVerticalSpeed = 0;
            if (controller._currentVerticalSpeed == 0)
            {
                controller._currentVerticalSpeed = bounceDog;
                controller._endedJumpEarly = false;

                animator.SetTrigger("jumpingThisFrame");
            }

        }
        if (collision.gameObject.CompareTag("GroundCheck"))
        {
            
                if (rb != null)
                {
                    Vector2 velocity = rb.velocity;
                    velocity.y = bounceCiego;
                    rb.velocity = velocity;
                }
            
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.CompareTag("GroundCheck"))
        //{
        //    if (collision.relativeVelocity.y <= 0f)
        //    {
        //        if (rb != null)
        //        {
        //            Vector2 velocity = rb.velocity;
        //            velocity.y = bounceCiego;
        //            rb.velocity = velocity;
        //        }
        //    }
        //}
    }

    void Update()
    {
        
    }
}
