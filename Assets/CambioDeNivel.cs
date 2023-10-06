using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class CambioDeNivel : MonoBehaviour
{

    [SerializeField] BoxCollider2D col2D;

    // Start is called before the first frame update
    void Setup()
    {
        OnTriggerEnter2D(col2D);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Jugador"))
        {
            SceneManager.LoadScene("Escena1");

        }
    }

}
