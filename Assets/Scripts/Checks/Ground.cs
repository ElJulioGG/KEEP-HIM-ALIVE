using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Ground : MonoBehaviour
{
   [SerializeField] private LayerMask platformLayerMask;
    [SerializeField] private Collider2D coliderPiso;
    private bool onGround =false;
    private float friction;

    private void Awake()
    {
        Collider2D coliderPiso = GetComponentInChildren<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // EvaluateCollision(collision);
        RetriveFriction(collision);
    }



    private void OnTriggerStay2D(Collider2D collision)
    {
        //EvaluateCollision(collision);
        // Check if the collision's layer is in the platformLayerMask
        if (((1 << collision.gameObject.layer) & platformLayerMask) != 0)
        {
            onGround = true;
            print("OnGround");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & platformLayerMask) != 0)
        {
            onGround = false;
            friction = 0;
            print("Not OnGround");
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
       
    }

    
    //private void EvaluateCollision(Collision2D collision)
    //{
    //    for (int i = 0; i < collision.contactCount; i++)
    //    {
    //        Vector2 normal = collision.GetContact(i).normal;

    //        // Check if the normal points upward and the contact point is close to the ground
    //        if (Vector2.Dot(normal, Vector2.up) > 0.9f && collision.GetContact(i).point.y <= transform.position.y)
    //        {
    //            onGround = true;
    //            return; // No need to continue checking
    //        }
    //    }
    //}
    private void RetriveFriction(Collision2D collision)
    {
        PhysicsMaterial2D material = collision.rigidbody.sharedMaterial;
        friction = 0;
        if(material != null)
        {
            friction = material.friction;
        }
    }
    public bool GetOnGround()
    {
        return onGround;
    }
    public float GetFriction()
    {
        return friction;
    }
}
