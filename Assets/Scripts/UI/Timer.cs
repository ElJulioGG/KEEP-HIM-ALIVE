using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;
    private float timeElapsed;
    private int minutos, segundos, centesimas;
    private bool alive = false;
    // Start is called before the first frame update
    [SerializeField] private int nivelActual; 
    public Animator animatorTimer;

    void Start()
    {
        Invoke("Resume",2f);
        animatorTimer.SetTrigger("TimerIn");
    }
    void Setup()
    {
        gameObject.SetActive(true);
        alive = false;
    }
    // Update is called once per frame
    private void Update()
    {
        if (alive) { 
            timeElapsed += Time.deltaTime;
            //timerText.text = timeElapsed.ToString();
            minutos = (int)(timeElapsed / 60f);
            segundos = (int)(timeElapsed - minutos * 60f);
            centesimas = (int)((timeElapsed - (int)timeElapsed) * 100f);

            timerText.text = string.Format("{0:00}:{1:00}:{2:00}", minutos, segundos, centesimas);
        }
    }
    public void Pause()
    {
        alive = false;
    }

    public void SaveTime()
    {
        animatorTimer.SetTrigger("TimerOut");
        switch (nivelActual)
        {
            case 0:
                if ((timeElapsed < GameManager.instance.TutorialTime) || (GameManager.instance.TutorialTime < 0.1f))
                {
                    GameManager.instance.TutorialTime = timeElapsed;
                }
                break;
            case 1:
                if ((timeElapsed < GameManager.instance.Nv1Time) || (GameManager.instance.Nv1Time < 0.1f))
                {
                    GameManager.instance.Nv1Time = timeElapsed;
                }
                break;
            case 2:
                if ((timeElapsed < GameManager.instance.Nv2Time) || (GameManager.instance.Nv2Time < 0.1f))
                {
                    GameManager.instance.Nv2Time = timeElapsed;
                }
                break;
            case 3:
                if ((timeElapsed < GameManager.instance.Nv3Time) || (GameManager.instance.Nv3Time < 0.1f))
                {
                    GameManager.instance.Nv3Time = timeElapsed;
                }
                break;
            case 4:
                if ((timeElapsed < GameManager.instance.Nv4Time) || (GameManager.instance.Nv4Time < 0.1f))
                {
                    GameManager.instance.Nv4Time = timeElapsed;
                }
                break;
            case 5:
                if ((timeElapsed < GameManager.instance.Nv5Time) || (GameManager.instance.Nv5Time < 0.1f))
                {
                    GameManager.instance.Nv5Time = timeElapsed;
                }
                break;
            case 6:
                if ((timeElapsed < GameManager.instance.Nv6Time) || (GameManager.instance.Nv6Time < 0.1f))
                {
                    GameManager.instance.Nv6Time = timeElapsed;
                }
                break;
            case 7:
                if ((timeElapsed < GameManager.instance.Nv7Time) || (GameManager.instance.Nv7Time < 0.1f))
                {
                    GameManager.instance.Nv7Time = timeElapsed;
                }
                break;
            case 8:
                if ((timeElapsed < GameManager.instance.Nv8Time) || (GameManager.instance.Nv8Time < 0.1f))
                {
                    GameManager.instance.Nv8Time = timeElapsed;
                }
                break;
        }
    }
        public void Resume()
    {
        alive = true;

    }
    void SetDown()
    {
        gameObject.SetActive(false);
    }
}
