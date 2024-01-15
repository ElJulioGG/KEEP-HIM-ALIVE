using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.ComponentModel;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int levelsCompleted = 0;

    public bool introHasPlayed = false;
    public bool reachEnding = false;

    public bool GameOver = false;

    public bool Nv1Complete = false;
    public bool Nv2Complete = false;
    public bool Nv3Complete = false;
    public bool Nv4Complete = false;
    public bool Nv5Complete = false;
    public bool Nv6Complete = false;
    public bool Nv7Complete = false;
    public bool Nv8Complete = false;
    public bool Nv9Complete = false;

    public float TutorialTime = 0f;
    public float Nv1Time = 0f;
    public float Nv2Time = 0f;
    public float Nv3Time = 0f;
    public float Nv4Time = 0f;
    public float Nv5Time = 0f;
    public float Nv6Time = 0f;
    public float Nv7Time = 0f;
    public float Nv8Time = 0f;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
