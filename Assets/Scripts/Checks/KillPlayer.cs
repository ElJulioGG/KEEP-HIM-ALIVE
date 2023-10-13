using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TarodevController;
public class KillPlayer : MonoBehaviour
{
    public PlayerController playerController;
    public GameObject Dog;
    public GameObject BloodPrefab;
    public GameObject Character;

    // Start is called before the first frame update
    public GameOverScript gameOverScript;


    bool death = false;
    public void Start()
    {
        // playerController = GetComponent<PlayerController>();
        gameOverScript = GameObject.Find("background").GetComponent<GameOverScript>();

    }

    // Update is called once per frame
    void Update()
    {   
       
        
    }
     void OnTriggerEnter2D(Collider2D other)
     {
        if (other.CompareTag("Jugador") || other.CompareTag("Ciego"))
        {
            Instantiate(BloodPrefab, other.CompareTag("Jugador") ? Dog.transform.position : Character.transform.position, Quaternion.identity);
            playerController.CantInput = true;
            
            if (other.CompareTag("Jugador"))
                Dog.SetActive(false);
            else
                Character.SetActive(false);
            AudioManager.instance.PlaySfx("Death");

            if (!death)
            {
                gameOverScript.Setup();
                death = true;
            }

        }
    }
}
