using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public static int scoreValue;
    TextMeshProUGUI score;
    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = $"Score: {scoreValue}";
    }
}