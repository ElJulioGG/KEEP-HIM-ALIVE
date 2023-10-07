using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TarodevController;
public class KillPlayer : MonoBehaviour
{
    public PlayerController playerController;
    
    // Start is called before the first frame update
    public GameOverScript gameOverScript;
    public void Start()
    {
     
    }
   
    // Update is called once per frame
    void Update()
    {   
       
        
    }
     void OnTriggerEnter2D(Collider2D other)
     {
        if (other.CompareTag("Jugador")|| other.CompareTag("Ciego"))
        {
            playerController.CantInput = true;
            gameOverScript.Setup();
        }
     }
}
