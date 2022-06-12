using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + ScoreScript.scoreValue;

        // if you want you can use this line:
        // this.GetComponent<TextMeshProUGUI>().text = "Score: " + ScoreScript.scoreValue;
    }
}
