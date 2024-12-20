using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Events;

public class Move : MonoBehaviour
{
    [SerializeField] private Collider2D coliderPared;
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
    public bool isOnEnd;
    public bool moverDerecha =false;
    public Animator animator;
    public UnityEvent evento;
    public bool IsEnabled = false;

    // Start is called before the first frame update
    private void Start()
    {
        Invoke("MakeEnabled", 2f);
    }
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        ground = GetComponent<Ground>();
        Collider2D coliderPared = GetComponentInChildren<Collider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (IsEnabled)
        {
            direction.x = input.RetriveMoveInput();

            if (CambioDeDireccion() || moverDerecha)
            {
                desiredVelocity = new Vector2(direction.x, 0f) * Mathf.Max(maxSpeed - ground.GetFriction(), 0f);
            }
            else
            {
                desiredVelocity = new Vector2(-direction.x, 0f) * Mathf.Max(maxSpeed - ground.GetFriction(), 0f);
            }
            if (onGround)
            {
                animator.SetBool("isJumping", false);
            }
            if (!onGround)
            {
                animator.SetBool("isJumping", true);
            }
        }
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
    void MakeEnabled()
    {
        IsEnabled = true;
        evento.Invoke();
    }
    private bool CambioDeDireccion()
    {
        //si el sprite a cambiado returnea true
        return transform.localScale.x > Mathf.Epsilon; //epsilon es un numero muy pequenio pero mayor a 0
    }

    public void debeGirar()
    { //hace que el sprite mire hacia otro el lado si se activa la funcion
        transform.localScale = new Vector2(-(Mathf.Sign(velocity.x)), transform.localScale.y); 
    }

    public void MoverDerecha()
    { //hace que el sprite mire hacia la derecha
        moverDerecha = true;
    }
    public void MoverIzquierda()
    { //hace que el sprite mire hacia la derecha
        moverDerecha = false;
    }


    //Para checkear la salida del nivel
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Salida"))
        {
            isOnEnd = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Salida"))
        {
            isOnEnd = false;
        }
    }
}
