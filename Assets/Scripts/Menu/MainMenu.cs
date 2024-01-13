using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class MainMenu : MonoBehaviour
{
    public Animator animatorIntroMenu;
    public Animator animatorMenu;
    public Animator animatorSelecNivel;
    public Animator animatorFadeInBlack;
    public Animator SkipText;

    public GameObject CanvasSelecNivel;
    public GameObject CanvasMenu;

    public Button MenuPlay;
    public Button MenuSelec;
    public Button MenuCredits;
    public Button MenuClose;

    IEnumerator IniciarMenu;
    IEnumerator IntroducirCorrutina;

    private bool musicStoped = false;
    private bool enCinematica = true;
    private bool mostrarMensaje = false;
    public VideoPlayer IntroPlayer;

    public GameObject CanvasPantalla;

    float skipTime = 1f;
    [SerializeField]float skipHold = 0f;

    // Start is called before the first frame update
    void Start()
    {
        IniciarMenu = InicioMenu();

        IntroducirCorrutina = IntroCorrutina();

        StartCoroutine(IntroducirCorrutina);
        
        //StartCoroutine(IniciarMenu);


        //if (!AudioManager.instance.musicSource.isPlaying && !musicStoped)
        //{
        //    AudioManager.instance.PlayMusic("MenuMusic");
        //}
        
    }

    // Update is called once per frame
    void Update()
    {
        skipCinematica();
        if (!enCinematica || GameManager.instance.introHasPlayed)
        {
            CanvasPantalla.SetActive(false);
            StopCoroutine(IntroducirCorrutina);
            IntroPlayer.Stop();
            StartCoroutine(IniciarMenu);
            enCinematica = true;
        }
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
    private void DesabilitarBotonesMenu()
    {
        MenuPlay.interactable = false;
        MenuSelec.interactable = false;
        MenuCredits.interactable = false;
        MenuClose.interactable = false;
    }
    private void habilitarBotonesMenu()
    {
        MenuPlay.interactable = true;
        MenuSelec.interactable = true;
        MenuCredits.interactable = true;
        MenuClose.interactable = true;
    }
    public void SalirJuego() {
        Application.Quit();
    }
    public void EscenaCred()
    {
        //SceneManager.LoadScene("Creditos");
    }

    void transitionSelecNivel()
    {

    }
    void skipCinematica()
    {
       
        if (enCinematica && Input.anyKey && !mostrarMensaje)
        {
             SkipText.SetBool("Fade",true);
            mostrarMensaje = true;
        }

        if (mostrarMensaje && Input.GetButton("Interact"))
        {
            skipHold = skipHold + Time.deltaTime;
            SkipText.SetBool("Fade", true);
        }
        else if (skipHold > 0)
        {
            skipHold = skipHold - Time.deltaTime;
            //SkipText.SetBool("Fade", false);
        }

        if (skipHold >= skipTime)
        {
            enCinematica = false;
            GameManager.instance.introHasPlayed = true;
        }
    }

    void cinematica()
    {
        enCinematica = true;
        IntroPlayer.Play();
    }

    IEnumerator IntroCorrutina()
    {
             yield return new WaitForSeconds(2f);

             AudioManager.instance.musicSource.Stop();
             cinematica();

             yield return new WaitForSeconds(38f);

             enCinematica = false;
             CanvasPantalla.SetActive(false); 
             GameManager.instance.introHasPlayed = true;
        yield return null;
    }
    IEnumerator InicioMenu() {
        DesabilitarBotonesMenu();
        animatorFadeInBlack.SetTrigger("FadeOut");

        yield return new WaitForSeconds(1f);
        
        animatorIntroMenu.SetTrigger("In");
        AudioManager.instance.PlayDoor("DoorIntro");
        AudioManager.instance.PlayMusic("MenuMusic");
        yield return new WaitForSeconds(0.8f);
        
        animatorMenu.SetTrigger("FadeIn");
        habilitarBotonesMenu();
        yield return null;
    }
}
