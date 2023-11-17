using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LuzBoton : MonoBehaviour
{
    public Light2D light2D;
    public float targetIntensity = 0.5f; 
    public float duration = 0.1f; 
    private float startIntensity;
    private bool isChangingIntensity = false;

    void Start()
    {
        if (light2D == null)
        {
            
            light2D = GetComponent<Light2D>();
        }

        if (light2D != null)
        {
            startIntensity = light2D.intensity;
        }
        else
        {
            Debug.LogError("Light2D component not found!");
        }
    }

    void Update()
    {
       
        //if (Input.GetKeyDown(KeyCode.Space) && !isChangingIntensity)
        //{
        //    StartIntensityChange();
        //}
    }

    public void StartIntensityChange()
    {
        // Reset the light intensity to the starting value
        light2D.intensity = startIntensity;

        // Use a coroutine to gradually change the intensity over time
        StartCoroutine(ChangeIntensityOverTime());
    }

    IEnumerator ChangeIntensityOverTime()
    {
        isChangingIntensity = true;

        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            // Lerp the intensity from the start to the target value using Time.deltaTime
            light2D.intensity = Mathf.Lerp(startIntensity, targetIntensity, elapsedTime / duration);

            // Update the elapsed time using Time.deltaTime
            elapsedTime += Time.deltaTime;

            yield return null; // Wait for the next frame
        }
        elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            // Lerp the intensity from the start to the target value using Time.deltaTime
            light2D.intensity = Mathf.Lerp(targetIntensity, startIntensity, elapsedTime / duration);

            // Update the elapsed time using Time.deltaTime
            elapsedTime += Time.deltaTime;

            yield return null; // Wait for the next frame
        }
        // Ensure the intensity reaches the target exactly
        light2D.intensity = 0;

        isChangingIntensity = false;
    }
}
