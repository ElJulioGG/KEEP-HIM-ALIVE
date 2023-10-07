using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;
using TarodevController;

public class CambioDeNivel : MonoBehaviour
{
    public PlayerController playerController;
    public Move move;

    [SerializeField] BoxCollider2D col2D;

    public UnityEvent Action;

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    private void Update()
    {
        if ((playerController.isOnEnd == true) && (move.isOnEnd == true))
        {
            Action.Invoke();
            
        }
    }

    public void SalidaDelNivel()
    {
        playerController.CantInput = true;
    }
    void Setup()
    {
        
    }


    void OnTriggerStay2D(Collider2D other)
    {
        if ((playerController.isOnEnd == true )&& (move.isOnEnd == true))
        {
            playerController.CantInput = true;
        }
    }
    //SceneManager.LoadScene("Escena1");
    //playerController.CantInput = true;

}
