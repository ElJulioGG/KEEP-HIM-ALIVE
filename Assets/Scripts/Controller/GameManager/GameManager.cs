using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int levelsCompleted = 0;


   public bool Nv1Complete = false;
   public bool Nv2Complete = false;
   public bool Nv3Complete = false;
   public bool Nv4Complete = false;
   public bool Nv5Complete = false;
   public bool Nv6Complete = false;
   public bool Nv7Complete = false;
   public bool Nv8Complete = false;
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
