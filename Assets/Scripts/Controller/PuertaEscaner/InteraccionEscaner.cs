using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteraccionEscaner : MonoBehaviour
{
    private BoxCollider2D m_BoxCollider;
    public bool isInRange;
   // public KeyCode interactKey;
    public UnityEvent interactAction;
    public Animator animatorPuerta;
    public Animator animatorCamara;
    public bool ActivatedCamera = false;

    void Start()
    {
        m_BoxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {

        animatorPuerta.SetTrigger("NotPressed");
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Jugador"))
        {

            isInRange = true;
            Debug.Log("esta en rango");
            interactAction.Invoke();
            animatorPuerta.SetTrigger("Pressed");
            animatorCamara.SetBool("Activada", true);
            if (!ActivatedCamera) { 
                m_BoxCollider.size = new Vector2(m_BoxCollider.size.x * 2, m_BoxCollider.size.y);
                ActivatedCamera = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Jugador"))
        {

            isInRange = false;
            Debug.Log("ya no esta en rango");
            interactAction.Invoke();
            animatorPuerta.SetTrigger("Pressed");
            animatorCamara.SetBool("Activada", false);
        }
    }
}
