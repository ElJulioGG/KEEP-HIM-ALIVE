using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TarodevController;
using TMPro;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject menuPausa;
    public Animator PausaTextAnimator;
    private PlayerController PlayerController;
    private bool isPaused = false;
    private bool isEnabled = false;

    private void Start()
    {
        Invoke("Setup", 2f);
        PlayerController = GameObject.Find("Dog")?.GetComponent<PlayerController>();
        isPaused = false;
    }
    public void Update()
    {
        if (GameManager.instance.GameOver)
        {
            isEnabled = false;
        }
        if (isEnabled)
        {
            if ((Input.GetButtonDown("Pause") && !isPaused))
            {
                Pausa();
            }
            else if ((Input.GetButtonDown("Pause") && isPaused))
            {
                Reanudar();
            }
        }
        
    }
    public void Pausa() {
        PlayerController.SetCantInput(true);
        Time.timeScale = 0.000001f;
        botonPausa.SetActive(false);
        menuPausa.SetActive(true);
        isPaused = true;
        PausaTextAnimator.SetTrigger("Hide");
        AudioManager.instance.FootStepsSource.volume = 0f; //hasta las huevas fix

    }
    public void Reanudar() {
        PlayerController.SetCantInput(false);
        Time.timeScale = 1f;
        botonPausa.SetActive(true);
        menuPausa.SetActive(false);
        isPaused = false;
        PausaTextAnimator.SetTrigger("Show");
        AudioManager.instance.FootStepsSource.volume = 0.8f;//hasta las huevas fix2
    }
    public void VolverMenu() {
        SceneManager.LoadScene("Menu");
    }
    public void Setup()
    {
        isEnabled = true;
        PausaTextAnimator.SetTrigger("FadeIn");
        //print("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
    }
    public void Setdown()
    {
        PausaTextAnimator.SetTrigger("FadeOut");
        isEnabled = false;
    }
}
