using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;
using TarodevController;
using System.Runtime.CompilerServices;

public class CambioDeNivel : MonoBehaviour
{
    public CameraManager cameraManager;
    public PlayerController playerController;
    public Move move;

    [SerializeField] BoxCollider2D col2D;

    public UnityEvent Action;
    public UnityEvent Fade;
    public bool moveCamera = false;

    bool fadeOut = false;
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    private void Update()
    {
        if ((playerController.isOnEnd == true) && (move.isOnEnd == true))
        {

            Invoke("CambioDeCamara", 2f);
            Action.Invoke();
        }
    }

    void CambioDeCamara()
    {
        if (moveCamera)
        {
            cameraManager.switchCamera(cameraManager.cameraAnim2);
            //print("lmao");
            moveCamera = false;
        }
    }
    public void SalidaDelNivel()
    {
        playerController.CantInput = true;
    }
    void Setup()
    {
        
    }
    void cambiarDeEscena()
    {
        SceneManager.LoadScene("Escena1");
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if ((playerController.isOnEnd == true) && (move.isOnEnd == true))
        {
            if (!fadeOut) {
                Fade.Invoke();
                fadeOut = true;
                moveCamera = true;
            }
            Invoke("cambiarDeEscena", 3f);
            playerController.CantInput = true;
            
        }
    }
    //SceneManager.LoadScene("Escena1");
    //playerController.CantInput = true;

}
