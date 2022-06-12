using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] foodPrefabs;
    private BoxCollider2D gridArea;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnFood", 0.0f, 1.0f);
        InvokeRepeating("SpawnRedFood", 10.0f, 15.0f);
        gridArea = GameObject.Find("GridArea").GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SnakeMovement.gameOver)
        {
            CancelInvoke();
        }
    }

    void SpawnFood()
    {
        Bounds gridAreaBounds = gridArea.bounds;

        float x = Mathf.Round(Random.Range(gridAreaBounds.min.x, gridAreaBounds.max.x));
        float y = Mathf.Round(Random.Range(gridAreaBounds.min.y, gridAreaBounds.max.y));

        Vector3 spawnPosition = new Vector3(x, y, 0.0f);


        Instantiate(foodPrefabs[0], spawnPosition, foodPrefabs[0].transform.rotation);

    }
    void SpawnRedFood()
    {
        Bounds gridAreaBounds = gridArea.bounds;

        float x = Mathf.Round(Random.Range(gridAreaBounds.min.x, gridAreaBounds.max.x));
        float y = Mathf.Round(Random.Range(gridAreaBounds.min.y, gridAreaBounds.max.y));

        Vector3 spawnPosition = new Vector3(x, y, 0.0f);

        Instantiate(foodPrefabs[1], spawnPosition, foodPrefabs[1].transform.rotation);
    }
}
