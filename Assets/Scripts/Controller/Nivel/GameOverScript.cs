using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using TarodevController;

public class GameOverScript : MonoBehaviour
{
    // public Text pointsText;

    public UnityEvent fadein;
    private Timer timer;
    private PlayerController PlayerController;

    public void Start()
    {
        PlayerController = GameObject.Find("Dog")?.GetComponent<PlayerController>();
        //timer = GameObject.Find("Timer").GetComponent<Timer>();
    }
    private void Awake()
    {
        timer = GameObject.Find("Timer").GetComponent<Timer>();
    }
    public void Setup(/*int score*/)
    {
        GameManager.instance.GameOver = true;
        gameObject.SetActive(true);
        fadein.Invoke();
        timer.Pause();
       // PlayerController.SetCantInput(true);
        // pointsText.text = score.ToString() + " Points ";
        //playerController.CantInput = true;
    }
    public void restartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void exitButton()
    {
        SceneManager.LoadScene("Menu");
    }
}
