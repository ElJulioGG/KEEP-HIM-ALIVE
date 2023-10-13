using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameOverScript : MonoBehaviour
{
    // public Text pointsText;
    public UnityEvent fadein;
 
    public void Start()
    {
        
    }
    public void Setup(/*int score*/)
    {
        gameObject.SetActive(true);
        fadein.Invoke();
        // pointsText.text = score.ToString() + " Points ";
        //playerController.CantInput = true;
        

    }
    public void restartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void exitButton()
    {
        SceneManager.LoadScene("Menu1");
    }
}
