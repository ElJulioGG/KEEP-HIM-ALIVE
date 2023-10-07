using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;


public class Move : MonoBehaviour
{


    [SerializeField] private InputController input = null;
    [SerializeField, Range(-100f, 100f)] private float maxSpeed = 4f;
    [SerializeField, Range(-100f, 100f)] private float maxAcceleration = 35f;
    [SerializeField, Range(-100f, 100f)] private float maxAirAcceleration = 20f;

    private Vector2 direction;
    private Vector2 desiredVelocity;
    private Vector2 velocity;
    private Rigidbody2D body;
    private Ground ground;
    private LayerMask Layer1;
    private bool CambioDireccion = false;
    private float maxSpeeChange;
    private float acceleration;
    private bool onGround;

    // Start is called before the first frame update
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        ground = GetComponent<Ground>();


    }

    // Update is called once per frame
    void Update()
    {
        direction.x = input.RetriveMoveInput();
        desiredVelocity = new Vector2(direction.x, 0f) * Mathf.Max(maxSpeed - ground.GetFriction(), 0f);
    }

    private void FixedUpdate()
    {
        onGround = ground.GetOnGround();
        velocity = body.velocity;

        acceleration = onGround ? maxAcceleration : maxAirAcceleration;
        maxSpeeChange = acceleration * Time.deltaTime;
        velocity.x = Mathf.MoveTowards(velocity.x, desiredVelocity.x, maxSpeeChange);
        

        body.velocity = velocity;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Wall") && !CambioDireccion) {
            Debug.Log("Colision!");
            
                maxSpeed = -maxSpeed;
                maxAcceleration = -maxAcceleration;
                maxAirAcceleration = -maxAirAcceleration;
            CambioDireccion = true;
           
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        CambioDireccion = false;
    }

}
