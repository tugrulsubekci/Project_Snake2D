using UnityEngine;

public class Food : MonoBehaviour
{
    private BoxCollider2D gridArea;
    private void Start()
    {
        gridArea = GameObject.Find("GridArea").GetComponent<BoxCollider2D>();
    }

    private void RandomizePosition()
    {
        Bounds gridAreaBounds = gridArea.bounds;

        float x = Mathf.Round(Random.Range(gridAreaBounds.min.x,gridAreaBounds.max.x));
        float y = Mathf.Round(Random.Range(gridAreaBounds.min.y,gridAreaBounds.max.y));

        transform.localPosition = new Vector3(x,y,0.0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
        } 
        else if (other.tag == "Food")
        {
            RandomizePosition();
        }
    }
}
