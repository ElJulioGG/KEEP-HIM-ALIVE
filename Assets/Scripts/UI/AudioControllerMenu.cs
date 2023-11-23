using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControllerMenu : MonoBehaviour
{
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickSound()
    {
        AudioManager.instance.PlayUI("ButtonClick");
    }
    public void OnHoverSound()
    {
        AudioManager.instance.PlayUI("ButtonHover");
    }
}
