using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Events;
public class LoadTimer : MonoBehaviour
{
    public CameraManager cameraManager;
    float currentTime = 0f;
    float startingTime = 3f;
    bool cameraSwitched = false;
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
                cameraManager.switchCamera(cameraManager.cameraJuego);
                cameraSwitched = true;
            }
        }

    }

    public void changeCamera()
    {
        //changecamera event
    }
}
