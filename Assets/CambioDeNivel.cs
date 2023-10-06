using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TarodevController;

public class CambioDeNivel : MonoBehaviour
{
    public PlayerController playerController;

    [SerializeField] BoxCollider2D col2D;

    // Start is called before the first frame update
    private void Start()
    {
       

    }
    void Setup()
    {

        playerController.CantInput = true;
    
        
        OnTriggerEnter2D(col2D);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Jugador"))
        {
             
                //SceneManager.LoadScene("Escena1");

        }
    }

}
