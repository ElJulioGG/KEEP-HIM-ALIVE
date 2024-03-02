    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBack : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private ControladorEscenas controlador;


    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        controlador = FindObjectOfType<ControladorEscenas>(); // Assuming ControladorEscenas is attached to another game object
    }

    // Start is called before the first frame update
    void Start()
    {
        rb2d.velocity = new Vector2(ControladorEscenas.instance.scrollSpeed,0);
    }

    // Update is called once per frame
    void Update()
    {
        if (ControladorEscenas.instance.gameOver)
        {
            rb2d.velocity = Vector2.zero;
        }
    }
}
