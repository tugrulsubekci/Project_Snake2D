using UnityEngine;
using System.Collections.Generic;

public class Food : MonoBehaviour
{
    private void Start()
    {
        RandomizePosition();
    }

    private void Update()
    {

    }

    public BoxCollider2D gridArea;
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
            RandomizePosition();
        } 
        else if (other.tag == "Food")
        {
            RandomizePosition();
        }
    }
}
