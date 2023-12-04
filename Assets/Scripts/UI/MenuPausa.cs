using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject botonPausa;

    [SerializeField] private GameObject menuPausa;

    public void Update()
    {
        if (Input.GetKey(KeyCode.O) && Time.timeScale != 0f)
        {
            Time.timeScale = 0f;
            botonPausa.SetActive(false);
            menuPausa.SetActive(true);
            
        }
        if (Input.GetKey(KeyCode.Escape) && Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            botonPausa.SetActive(true);
            menuPausa.SetActive(false);
        }
    }
    public void Pausa() {
        Time.timeScale = 0f;
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
}
