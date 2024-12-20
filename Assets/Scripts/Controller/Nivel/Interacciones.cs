using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interacciones : MonoBehaviour
{
    public bool isInRange;
    //public KeyCode interactKey;
    public UnityEvent interactAction;
    public Animator animator;

    void Start()
    {

    }
    void Update()
    {
        if (isInRange)
        {
            if (Input.GetButtonDown("Interact"))
            {
                interactAction.Invoke();
                animator.SetTrigger("Pressed");
                
            }
            animator.SetTrigger("NotPressed");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Jugador"))
        {
            
            isInRange = true;
            Debug.Log("esta en rango");

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Jugador"))
        {
            isInRange = false;
            Debug.Log("ya no esta en rango");

        }
    }
}

