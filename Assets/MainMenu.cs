using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private bool musicStoped=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!AudioManager.instance.musicSource.isPlaying && !musicStoped)
        {
            AudioManager.instance.PlayMusic("MenuMusic");
        }
    }
    public void EscenaJuego() {
        musicStoped = true;
        AudioManager.instance.musicSource.Stop();
        SceneManager.LoadScene("Escena0");
    }
    public void EscendaMenu() {
        SceneManager.LoadScene("Menu");
    }
    public void EscenaSeleccionarNivel() {
        SceneManager.LoadScene("SeleccionarNivel");
    }
}