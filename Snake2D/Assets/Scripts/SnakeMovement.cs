using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    public List<Transform> _segments = new List<Transform>();
    public Transform segmentPrefab;
    public int initialSize = 4;
    public Vector2 direction = Vector2.right;

    // turning head
    private Vector3 rightHead = new Vector3(0, 0, 0);
    private Vector3 upHead = new Vector3(0, 0, 90);
    private Vector3 leftHead = new Vector3(0, 0, 180);
    private Vector3 downHead = new Vector3(0, 0, 270);

    private void Start()
    {
        ResetState();
        this.transform.localEulerAngles = rightHead; // turning head
    }
    void Update()
    {
        // Snake Head Movement
        if (this.direction.x != 0.0f)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                this.direction = Vector2.up;
                this.transform.localEulerAngles = upHead; // turning head
            }
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                this.direction = Vector2.down;
                this.transform.localEulerAngles = downHead; // turning head
            }
        }

        else if (this.direction.y != 0.0f)
        {
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                this.direction = Vector2.right;
                this.transform.localEulerAngles = rightHead; // turning head
            }
            else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                this.direction = Vector2.left;
                this.transform.localEulerAngles = leftHead; // turning head
            }
        }
    }

    private void FixedUpdate()
    {
        // Snake Body positioning
        for (int i = _segments.Count - 1; i > 0; i--)
        {
            _segments[i].position = _segments[i - 1].position;
        }
        // Snake Head Movement
        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + this.direction.x,
            Mathf.Round(this.transform.position.y) + this.direction.y);
    }

    // Snake Growing
    public void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;
        _segments.Add(segment);
    }

    // Game Over
    public void ResetState()
    {
        this.direction = Vector2.right;
        this.transform.position = Vector3.zero;

        for (int i = 1; i < _segments.Count; i++)
        {
            Destroy(_segments[i].gameObject);
        }

        _segments.Clear();
        _segments.Add(this.transform);

        for (int i = 0; i < this.initialSize - 1; i++)
        {
            Grow();
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food")
        {
            Grow();
            FindObjectOfType<AudioManager>().Play("Eating");
        }

        else if (other.tag == "Obstacle")
        {
            ResetState();
            FindObjectOfType<AudioManager>().Play("GameOver");

            var Foods = GameObject.FindGameObjectsWithTag("Food");
            foreach (var food in Foods)
            {
                Destroy(food);
            }

        }
    }
}