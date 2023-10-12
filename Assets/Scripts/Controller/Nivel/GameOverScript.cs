using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    // public Text pointsText;

 
    public void Start()
    {
        
    }
    public void Setup(/*int score*/)
    {
        gameObject.SetActive(true);
        // pointsText.text = score.ToString() + " Points ";
        //playerController.CantInput = true;
        

    }
    public void restartButton()
    {
        SceneManager.LoadScene("Escena1");
    }
    public void exitButton()
    {
        SceneManager.LoadScene("Menu1");
    }
}
