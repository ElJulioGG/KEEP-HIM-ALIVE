using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour
{

    public int columnPoolSize = 5;
    public GameObject columnsPrefab;
    public GameObject columnsPrefab2;


    private GameObject[] columns;
    private Vector2 objectPoolPosition = new Vector2(-5, 0);
    private float timeSinceLastSpawned;
    public float spawRate;
    public float columnMin=-2.9f;
    public float columnMax = 1.4f;
    public float spawnPositionX = 10f;
    private int currentColumn;
    public GameObject[] prefabs;

    // Start is called before the first frame update
    void Start()
    {
        columns = new GameObject[columnPoolSize];
        for (int i = 0; i < columnPoolSize; i++)
        {
            GameObject prefabToSpawn;
            if (Random.Range(0, 2) == 0)
            {
                prefabToSpawn = columnsPrefab;
            }
            else
            {
                prefabToSpawn = columnsPrefab2;
            }

            columns[i] = Instantiate(prefabToSpawn, objectPoolPosition, Quaternion.identity);
        }
        Spawn();
    }


    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;
        if (!ControladorEscenas.instance.gameOver && timeSinceLastSpawned >= spawRate) {
            timeSinceLastSpawned = 0;
            Spawn();

        }

    }
    void Spawn()
    {
        float spawnYPosition = Random.Range(columnMin, columnMax);

        GameObject prefabToSpawn;
        if (Random.Range(0, 2) == 0)
        {
            prefabToSpawn = columnsPrefab;
        }
        else
        {
            prefabToSpawn = columnsPrefab2;
        }

        columns[currentColumn].transform.position = new Vector2(spawnPositionX, spawnYPosition);
        currentColumn++;
        if (currentColumn >= columnPoolSize)
        {
            currentColumn = 0;
        }
    }
}
