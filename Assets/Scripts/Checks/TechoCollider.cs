using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TarodevController;
public class TechoCollider : MonoBehaviour
{
    [SerializeField] private LayerMask platformLayerMask;
    public PlayerController Controller;
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
        if (((1 << collision.gameObject.layer) & platformLayerMask) != 0)
        {
            Controller.ColTecho =true;
            print("colTECHO");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & platformLayerMask) != 0)
        {
            Controller.ColTecho = false;
            print("salio colTECHO");
        }
    }
}
