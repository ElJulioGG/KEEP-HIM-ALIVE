using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Animator animatorMenu;
    public Animator animatorSelecNivel;

    public GameObject CanvasSelecNivel;
    public GameObject CanvasMenu;

    private bool musicStoped=false;
    // Start is called before the first frame update
    void Start()
    {
        //if (!AudioManager.instance.musicSource.isPlaying && !musicStoped)
        //{
        //    AudioManager.instance.PlayMusic("MenuMusic");
        //}
        AudioManager.instance.PlayMusic("MenuMusic");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EscenaJuego() {
        musicStoped = true;
        AudioManager.instance.musicSource.Stop();
        SceneManager.LoadScene(1);
    }
    public void EscenaMenu() {

        CanvasMenu.SetActive(true);

        animatorMenu.SetTrigger("FadeIn");
        animatorSelecNivel.SetTrigger("FadeOut");

    }
    public void EscenaSeleccionarNivel() {
        CanvasSelecNivel.SetActive(true);

        animatorMenu.SetTrigger("FadeOut");
        animatorSelecNivel.SetTrigger("FadeIn");

    }
    public void EscenaCred()
    {
        //SceneManager.LoadScene("Creditos");
    }

    void transitionSelecNivel()
    {

    }
   
}
