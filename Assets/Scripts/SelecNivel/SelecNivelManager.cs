using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelecNivelManager : MonoBehaviour
{
    private bool musicStoped = false;
    // Start is called before the first frame update
    void Start()
    {
        //if (!AudioManager.instance.musicSource.isPlaying /*&& !musicStoped*/)
        //{
        //    AudioManager.instance.PlayMusic("MenuMusic");
        //}
        //AudioManager.instance.PlayMusic("MenuMusic");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SelecNivel(int nivel)
    {
        Invoke("introAnim", 3f);
        musicStoped = true;
        AudioManager.instance.musicSource.Stop();
        switch (nivel)
        {
            case 0:
                SceneManager.LoadScene("Escena0");
                break;
            case 1:
                SceneManager.LoadScene("Escena1");
                break;
            case 2:
                SceneManager.LoadScene("Escena2");
                break;
            case 3:
                SceneManager.LoadScene("Escena3");
                break;
            case 4:
                SceneManager.LoadScene("Escena4");
                break;
            case 5:
                SceneManager.LoadScene("Escena5");
                break;
            case 6:
                SceneManager.LoadScene("Escena6");
                break;
            case 7:
                SceneManager.LoadScene("Escena7");
                break;
            case 8:
                SceneManager.LoadScene("Escena8");
                break;
        }
    }
    void introAnim()
        {

        }
    public void SelecMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}