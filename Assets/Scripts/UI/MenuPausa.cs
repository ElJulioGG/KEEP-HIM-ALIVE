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
    public GameObject PausaText;
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
        if (isEnabled)
        {
            if ((Input.GetButtonDown("Pause") && !isPaused))
            {
                PlayerController.SetCantInput(true);
                Time.timeScale = 0.000001f;
                botonPausa.SetActive(false);
                menuPausa.SetActive(true);
                isPaused = true;

            }
            else if ((Input.GetButtonDown("Pause") && isPaused))
            {
                PlayerController.SetCantInput(false);
                Time.timeScale = 1f;
                botonPausa.SetActive(true);
                menuPausa.SetActive(false);
                isPaused = false;

            }
        }
    }
    public void Pausa() {
        Time.timeScale = 0.000001f;
        botonPausa.SetActive(false);
        menuPausa.SetActive(true);
        
    }
    public void Reanudar() {
        Time.timeScale = 1f;
        botonPausa.SetActive(true);
        menuPausa.SetActive(false);
    }
    public void VolverMenu() {
        SceneManager.LoadScene("Menu");
    }
    public void Setup()
    {
        isEnabled = true;
        PausaText.SetActive(true);
    }
}
