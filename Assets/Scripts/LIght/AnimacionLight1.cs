using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class AnimacionLight1 : MonoBehaviour
{

    public Light2D light2D;

    void Start()
    {
        if (light2D == null)
        {

            light2D = GetComponent<Light2D>();
        }
      

    }

    void Update()
    {

        //if (Input.GetKeyDown(KeyCode.Space) && !isChangingIntensity)
        //{
        //    StartIntensityChange();
        //}
    }

    public void ChangeIntensityToOff()
    {
        light2D.intensity = 0.0f;
    }

    public void ChangeIntensityToOn()
    {
        light2D.intensity = 0.2f;
    }
}
   