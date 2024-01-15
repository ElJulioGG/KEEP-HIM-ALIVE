using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CreditosShow : MonoBehaviour
{
    // Start is called before the first frame update
    public int isClickCred = 0;
    public GameObject botonJugar;
    public GameObject botonSelec;
    public GameObject canvasCred;
    public TextMeshProUGUI creditosText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void clickCred()
    {
        if (isClickCred == 0)
        {
            canvasCred.SetActive(true);
            botonJugar.SetActive(false);
            botonSelec.SetActive(false);
            creditosText.text = "Menu";
            isClickCred = 1;
        }else 
        if(isClickCred == 1)
        {
            canvasCred.SetActive(false);
            botonJugar.SetActive(true);
            botonSelec.SetActive(true);
            creditosText.text = "Creditos";
            isClickCred = 0;
        }
    }
}
