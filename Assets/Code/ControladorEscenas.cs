using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
    
public class ControladorEscenas : MonoBehaviour
{
    public static ControladorEscenas instance;
    public GameObject canvasperdiste;
    public bool gameOver;
    public float scrollSpeed = -1.5f;
    private int score;
    public Text scoretext;

    public int pointtotal { get { return pointtotales; } }
    private int pointtotales;


    public void SumarPuntos(int puntosumar) {
        pointtotales +=  puntosumar;
       
    }



    private void Awake()
    {
        if (ControladorEscenas.instance == null) {
            ControladorEscenas.instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else if (ControladorEscenas.instance != this) {
            Destroy(gameObject);
            Debug.LogWarning("Gaa");
        }

    }

    public void BirdScore() {
        if (gameOver) return;
        score++;
        scoretext.text="Score: "+score;
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale=1;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reiniciar() {
        SceneManager.LoadScene("Menu");

    }

    public void BirdDie()
    {
        canvasperdiste.SetActive(true);
        Time.timeScale = 0;
        gameOver = true;
    }



    private void OnDestroy()
    {
        if (ControladorEscenas.instance==this) {
            ControladorEscenas.instance = null;
            }
    }

}
