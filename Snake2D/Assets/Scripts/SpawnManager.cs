using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] foodPrefabs;
    private BoxCollider2D gridArea;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnFood", 0.0f, 0.1f);
        InvokeRepeating("SpawnRedFood", 10.0f, 15.0f);
        gridArea = GameObject.Find("GridArea").GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnFood()
    {
        int a = 0;
        Bounds gridAreaBounds = gridArea.bounds;

        float x = Mathf.Round(Random.Range(gridAreaBounds.min.x, gridAreaBounds.max.x));
        float y = Mathf.Round(Random.Range(gridAreaBounds.min.y, gridAreaBounds.max.y));

        Vector3 spawnPosition = new Vector3(x, y, 0.0f);

        foreach (Transform segment in SnakeMovement._segments)
        {
            if(segment.position != spawnPosition)
            {
                a++;
            }
        }

        if (a == SnakeMovement._segments.Count)
        {
            Instantiate(foodPrefabs[0], spawnPosition, foodPrefabs[0].transform.rotation);
        }
        else if (a != SnakeMovement._segments.Count)
        {
            SpawnFood();
        }
    }
    void SpawnRedFood()
    {
        int a = 0;
        Bounds gridAreaBounds = gridArea.bounds;

        float x = Mathf.Round(Random.Range(gridAreaBounds.min.x, gridAreaBounds.max.x));
        float y = Mathf.Round(Random.Range(gridAreaBounds.min.y, gridAreaBounds.max.y));

        Vector3 spawnPosition = new Vector3(x, y, 0.0f);

        for (int i = 0; i < SnakeMovement._segments.Count; i++)
        {
            if (spawnPosition != SnakeMovement._segments[i].position)
            {
                a++;
            }
        }
        if (a == SnakeMovement._segments.Count)
        {
            Instantiate(foodPrefabs[1], spawnPosition, foodPrefabs[1].transform.rotation);
        }
        else if (a != SnakeMovement._segments.Count)
        {
            SpawnRedFood();
        }
    }
}
