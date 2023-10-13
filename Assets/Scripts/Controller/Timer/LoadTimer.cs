using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LoadTimer : MonoBehaviour
{
    public UnityEvent evento;
    public CameraManager cameraManager;

    float currentTime = 0f;
    float startingTime = 1f;
    bool cameraSwitched = false;
    bool charactersInstantiaded = false;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
       // print(currentTime);
        if(currentTime < 0)
        {
            
            //print("PENEEEEEEEEEE");
            currentTime = 0;
            if (!cameraSwitched)
            {
                evento.Invoke();
                cameraManager.switchCamera(cameraManager.cameraJuego);
                cameraSwitched = true;
                //if (SceneManager.GetActiveScene().buildIndex > 1)
                //{
                    if (!AudioManager.instance.musicSource.isPlaying)
                    {
                        AudioManager.instance.PlayMusic("LevelMusic");
                        
                    }
                //}
                //if (SceneManager.GetActiveScene().buildIndex == 1)
                //{
                //    if (!AudioManager.instance.musicSource.isPlaying)
                //    {
                //        AudioManager.instance.PlayMusic("Tutorial");

                //    }
                //}

            }
            if (!charactersInstantiaded)
            {

                charactersInstantiaded= true;   
            }
        }

    }

    public void changeCamera()
    {
        //changecamera event
    }
}
