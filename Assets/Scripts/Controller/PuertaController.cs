using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaController : MonoBehaviour
{

    [SerializeField] BoxCollider2D col2D;
    public bool estaCerrado;
    public Animator animator;
    
    public void OpenPuerta()
    {
        if (estaCerrado)
        {
            estaCerrado = false;
            animator.SetBool("Cerrado", estaCerrado);
            col2D.enabled = false;
            Debug.Log("Puerta abierta");
        }else
        {
            estaCerrado = true;
            animator.SetBool("Cerrado", estaCerrado);
            col2D.enabled = true;
            Debug.Log("Puerta Cerrada");
        }
    }
    
}
