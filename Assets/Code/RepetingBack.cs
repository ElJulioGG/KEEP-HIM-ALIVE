using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repeting : MonoBehaviour
{
    private BoxCollider2D groundCollider;
    private float groundHorizontalLenght;

    private void Awake()
    {
        groundCollider = GetComponent<BoxCollider2D>();

    }

    // Start is called before the first frame update
    void Start()
    {
        groundHorizontalLenght = groundCollider.size.x;
    }

    private void RepetitionBackground()
    {
        transform.Translate(Vector2.right * groundHorizontalLenght * 2);
        //Vector2 groundOfset = new Vector2(groundHorizontalLenght * 2f, 0);
        //transform.position = (Vector2)transform.position + groundOfset;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -groundHorizontalLenght)
        {
            RepetitionBackground();
        }


    }
}
