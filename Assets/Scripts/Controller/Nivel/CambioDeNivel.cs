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
    GameManager gameManager;
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
            print("daw"); 
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
        if (SceneManager.GetActiveScene().buildIndex == 1 && !GameManager.instance.Nv1Complete)
        {
            GameManager.instance.levelsCompleted += 1;
            GameManager.instance.Nv1Complete = true;
        }
        if (SceneManager.GetActiveScene().buildIndex == 2 && !GameManager.instance.Nv2Complete)
        {
            GameManager.instance.levelsCompleted += 1;
            GameManager.instance.Nv2Complete = true;
        }
        if (SceneManager.GetActiveScene().buildIndex == 3 && !GameManager.instance.Nv3Complete)
        {
            GameManager.instance.levelsCompleted += 1;
            GameManager.instance.Nv3Complete = true;
        }
        if (SceneManager.GetActiveScene().buildIndex == 4 && !GameManager.instance.Nv4Complete)
        {
            GameManager.instance.levelsCompleted += 1;
            GameManager.instance.Nv4Complete = true;
        }
        if (SceneManager.GetActiveScene().buildIndex == 5 && !GameManager.instance.Nv5Complete)
        {
            GameManager.instance.levelsCompleted += 1;
            GameManager.instance.Nv5Complete = true;
        }
        if (SceneManager.GetActiveScene().buildIndex == 6 && !GameManager.instance.Nv6Complete)
        {
            GameManager.instance.levelsCompleted += 1;
            GameManager.instance.Nv6Complete = true;
        }
        if (SceneManager.GetActiveScene().buildIndex == 7 && !GameManager.instance.Nv7Complete)
        {
            GameManager.instance.levelsCompleted += 1;
            GameManager.instance.Nv7Complete = true;
        }
        if (SceneManager.GetActiveScene().buildIndex == 8 && !GameManager.instance.Nv8Complete)
        {
            GameManager.instance.levelsCompleted += 1;
            GameManager.instance.Nv8Complete = true;
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
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
