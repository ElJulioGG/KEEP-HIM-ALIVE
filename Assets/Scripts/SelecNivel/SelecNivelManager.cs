using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelecNivelManager : MonoBehaviour
{
    private bool musicStoped = false;
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
    public void SelecTutorial()
    {
        musicStoped = true;
        AudioManager.instance.musicSource.Stop();
        SceneManager.LoadScene(1);
    }
    public void SelecNivel1()
    {
        musicStoped = true;
        AudioManager.instance.musicSource.Stop();
        SceneManager.LoadScene(2);
    }
    public void SelecNivel2()
    {
        musicStoped = true;
        AudioManager.instance.musicSource.Stop();
        SceneManager.LoadScene(3);
    }
    public void SelecMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}