using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class TimerSelecNivel : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;
    private float timeElapsed;
    private int minutos, segundos, centesimas;
    private bool alive = true;
    
    [SerializeField] private int nivelBotton;

    void Start()
    {
        if (alive)
        {
            switch (nivelBotton)
            {
                case 0:
                    timeElapsed = GameManager.instance.TutorialTime;
                    break;
                case 1:
                    timeElapsed = GameManager.instance.Nv1Time;
                    break;
                case 2:
                    timeElapsed = GameManager.instance.Nv2Time;
                    break;
                case 3:
                    timeElapsed = GameManager.instance.Nv3Time;
                    break;
                case 4:
                    timeElapsed = GameManager.instance.Nv4Time;
                    break;
                case 5:
                    timeElapsed = GameManager.instance.Nv5Time;
                    break;
                case 6:
                    timeElapsed = GameManager.instance.Nv6Time;
                    break;
                case 7:
                    timeElapsed = GameManager.instance.Nv7Time;
                    break;
                case 8:
                    timeElapsed = GameManager.instance.Nv8Time;
                    break;
            }
            minutos = (int)(timeElapsed / 60f);
            segundos = (int)(timeElapsed - minutos * 60f);
            centesimas = (int)((timeElapsed - (int)timeElapsed) * 100f);

            timerText.text = string.Format("{0:00}:{1:00}:{2:00}", minutos, segundos, centesimas);
        }
    }
    void Setup()
    {
        gameObject.SetActive(true);
        alive = false;
    }
    // Update is called once per frame
    private void Update()
    {
      
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