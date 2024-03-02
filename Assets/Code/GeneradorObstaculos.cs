using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorObstaculos : MonoBehaviour
{
    public float tiempoMax = 1;
    private float tiempoinicial = 0;
    public GameObject obstaculo;
    public float altura;
    // Start is called before the first frame update
    void Start()
    {
        GameObject obstaculonew = Instantiate(obstaculo);
        obstaculonew.transform.position = transform.position + new Vector3(0, 0, 0);
        Destroy(gameObject, 10);
    }

    // Update is called once per frame
    void Update()
    {
        if (tiempoinicial > tiempoMax)
        {
            GameObject obstaculonew = Instantiate(obstaculo);
            obstaculonew.transform.position = transform.position + new Vector3(0, (Random.Range(-altura, altura)), 0);
            Destroy(gameObject, 10);
            tiempoinicial = 0;
        }
        else {
            tiempoinicial += Time.deltaTime;
        }
    }
}
