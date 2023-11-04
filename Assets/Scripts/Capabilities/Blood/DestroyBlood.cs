using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBlood : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 10f);
        //print("Destroyed");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnDestroy()
    {
        Debug.Log("The object has been destroyed!");
    }
}
