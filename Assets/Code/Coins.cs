using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public int valor = 1;
    public ControladorEscenas controlador;

    private void Awake()
    {
        controlador = ControladorEscenas.instance;

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            controlador.SumarPuntos(valor);
            SoundSystem.instance.PlayCoin();
            Destroy(this.gameObject);
        }
    }
}
