using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TarodevController;
public class FlipPlayer : MonoBehaviour
{
    public PlayerController controller;
    bool derecha = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (controller._currentHorizontalSpeed > 0 && !derecha)
        {
            flip();
        }
        if (controller._currentHorizontalSpeed < 0 && derecha)
        {
            flip();
        }
    }
    void flip()
    {
        Vector3 characterScale = transform.localScale;
            characterScale.x *= -1;
            
        transform.localScale = characterScale;

        derecha = !derecha;
        Debug.Log("flip");
    }
}
