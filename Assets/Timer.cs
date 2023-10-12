using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;
    private float timeElapsed;
    private int minutos, segundos, centesimas;
    private bool alive = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Setup()
    {
        gameObject.SetActive(true);
        alive = true;
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
    void SetDown()
    {
        gameObject.SetActive(false);
    }
}
