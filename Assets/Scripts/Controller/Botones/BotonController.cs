using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonController : MonoBehaviour
{

    [SerializeField] int levelBoton;
    private Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        if (GameManager.instance.levelsCompleted >= levelBoton)
        {
            button.interactable = true;
        }
        else
        {
            button.interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.levelsCompleted >= levelBoton)
        {
            button.interactable = true;
        }
        else
        {
            button.interactable = false;
        }
    }
}
