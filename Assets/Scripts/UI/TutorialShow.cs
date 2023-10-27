using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialShow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MostrarTutorial()
    {
        Invoke("Activar", 1f);
    }
    public void QuitarTutorial()
    {
        Invoke("Desactivar", 1f);
    }
    public void Activar()
    {
        gameObject.SetActive(true);
    }
    public void Desactivar()
    {
        gameObject.SetActive(false);
    }
}
