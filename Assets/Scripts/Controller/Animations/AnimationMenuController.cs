using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // StartCoroutine();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Sucesos()
    {

        yield return null;
        yield return new WaitForSeconds(1);
    }
}
