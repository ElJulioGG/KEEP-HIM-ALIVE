using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteraccionEntrada : MonoBehaviour
{
    public bool isInRange;
    //public UnityEvent interactAction;
    public Animator animator;

    public bool cerrar = false;
    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("Abierto", true);
        animator.SetBool("Cerrado", false);
    }

    // Update is called once per frame
    void Update()
    {

        if (isInRange)
        {
            if (!cerrar) {
                animator.SetBool("Abierto", true);
                
            }
            animator.SetBool("Cerrado", false);
        }
        else
        {
            animator.SetBool("Cerrado", true);
            animator.SetBool("Abierto", false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Jugador") /*|| collision.gameObject.CompareTag("Ciego")*/)
        {
            
            isInRange = true;
            Debug.Log("esta en rango");

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Jugador") /*|| collision.gameObject.CompareTag("Ciego")*/)
        {
            if (!cerrar)
            {
                AudioManager.instance.PlayDoor("DoorOpen");
            }
            isInRange = false;
            Debug.Log("ya no esta en rango");
            cerrar = true;

        }
    }
}
