using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
   
    public CinemachineVirtualCamera[] cameras;

    public CinemachineVirtualCamera cameraAnim1;
    public CinemachineVirtualCamera cameraJuego;
    public CinemachineVirtualCamera cameraAnim2;

    public CinemachineVirtualCamera startCamera;
    private CinemachineVirtualCamera currentCam;
    


    // Start is called before the first frame update
    void Start()
    {
        currentCam = startCamera;
        for(int i = 0; i< cameras.Length; i++)
        {
            if (cameras[i] == currentCam)
            {
                cameras[i].Priority = 20;
            }
            else
            {
                cameras[i].Priority = 10;
            }
        }
    }

    public void switchCamera(CinemachineVirtualCamera newCam)
    {
        currentCam = newCam;
        currentCam.Priority = 20;
        for (int i = 0; i < cameras.Length; i++)
        {
            if (cameras[i] != currentCam)
            {
                cameras[i].Priority = 10;
            }
        }
    }
}
