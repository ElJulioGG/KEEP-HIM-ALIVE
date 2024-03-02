using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaPersonaje : MonoBehaviour
{
    private bool isDead;
    public float velocity = 10;
    private Rigidbody2D rb;
    private Animator animator;
    // Start is called before the first frame update

    public ControladorEscenas controladorEscenas;
        void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            SoundSystem.instance.PlayJump();
            rb.velocity=Vector2.up * velocity*4;
            animator.SetTrigger("isFlap");
           


        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SoundSystem.instance.PlayDeath();
        ControladorEscenas.instance.BirdDie();
        animator.SetTrigger("isDead");
       

    }
}
