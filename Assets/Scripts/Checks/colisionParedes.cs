using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colisionParedes : MonoBehaviour
{
    [SerializeField] public Move move;
    // Start is called before the first frame update

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Platform"))
        {
            move.debeGirar();
        }
    }
}
