using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            ControladorEscenas.instance.BirdScore(); 
        }
    }

    internal void SetColumnType(GameObject prefabToSpawn)
    {
        throw new NotImplementedException();
    }
}
