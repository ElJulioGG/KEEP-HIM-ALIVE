using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInCanvas : MonoBehaviour
{
    public CanvasRenderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<CanvasRenderer>();
        if (rend == null)
        {
            Debug.LogError("CanvasRenderer component not found.");
            return;
        }

        Color c = rend.GetColor();
        c.a = 0f;
        rend.SetColor(c);
    }

    IEnumerator FadeInFunction()
    {
        if (rend == null)
        {
            Debug.LogError("CanvasRenderer component is not properly assigned.");
            yield break;
        }

        float increment = 0.1f; // Adjust this value to control the speed of the fade

        for (float f = 0.0f; f <= 1; f += increment)
        {
            Color c = rend.GetColor();
            c.a = f;
            rend.SetColor(c);
            yield return new WaitForSeconds(0.05f); // Adjust this value for the delay between increments
        }

        // Ensure the final alpha is exactly 1
        Color finalColor = rend.GetColor();
        finalColor.a = 1f;
        rend.SetColor(finalColor);
    }

    public void StartFading()
    {
        StartCoroutine("FadeInFunction");
    }
}
