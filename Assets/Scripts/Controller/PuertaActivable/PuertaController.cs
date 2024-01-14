using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaController : MonoBehaviour
{

    [SerializeField] GameObject col2D;
    public bool estaCerrado;
    public bool mute = false;
    public Animator animatorBoton;
    public Animator animatorPuerta;

    private void Start()
    {
        if (estaCerrado)
        {
            estaCerrado = false;
            animatorBoton.SetBool("Cerrado", estaCerrado);
            animatorPuerta.SetBool("Cerrado", estaCerrado);
            col2D.SetActive(false);
            Debug.Log("Puerta abierta");
           // AudioManager.instance.PlayDoor("IntDoorOpen");
        }
        else
        {
            estaCerrado = true;
            animatorBoton.SetBool("Cerrado", estaCerrado);
            animatorPuerta.SetBool("Cerrado", estaCerrado);
            col2D.SetActive(true);
            Debug.Log("Puerta Cerrada");
           // AudioManager.instance.PlayDoor("IntDoorClose");
        }
    }
    public void OpenPuerta()
    {
        if (estaCerrado)
        {
            estaCerrado = false;
            animatorBoton.SetBool("Cerrado", estaCerrado);
            animatorPuerta.SetBool("Cerrado", estaCerrado);
            col2D.SetActive(false);
            Debug.Log("Puerta abierta");
            if (!mute)
            {
                AudioManager.instance.PlayDoor("IntDoorOpen");
            }
        }
        else
        {
            estaCerrado = true;
            animatorBoton.SetBool("Cerrado", estaCerrado);
            animatorPuerta.SetBool("Cerrado", estaCerrado);
            col2D.SetActive(true);
            Debug.Log("Puerta Cerrada");
            if (!mute)
            {
                AudioManager.instance.PlayDoor("IntDoorClose");
            }
        }
    }
    
}
