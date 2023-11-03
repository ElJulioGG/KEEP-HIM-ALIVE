using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTextDestroy : MonoBehaviour
{
    [SerializeField] public float DestroyTime = 3.0f;

    [SerializeField] public Vector3 Offset = new Vector3 (0, 2, 0);

    [SerializeField] public Vector3 RandomizeIntensity = new Vector3(0.5f, 0, 0);
    


    // Start is called before the first frame update
    void Start()
    {
        float randomRotation = Random.Range(-10f, 10f);
        Vector3 randomMovX = new Vector3(Random.Range(-RandomizeIntensity.x, RandomizeIntensity.x),
            Random.Range(-RandomizeIntensity.y, RandomizeIntensity.y),
            Random.Range(-RandomizeIntensity.z, RandomizeIntensity.z));

        

        Destroy(gameObject, DestroyTime);
        transform.localPosition += Offset;
        transform.localPosition += randomMovX;
        transform.localRotation = Quaternion.Euler(0f,0f, randomRotation);
            
    }

    
}
