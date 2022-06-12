using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI scoreInScreen;
    public void Setup(int score)
    {
        gameObject.SetActive(true);
        scoreInScreen.text = $"Score: {score}";
    }
    public void RestartButton()
    {
        SceneManager.LoadScene("Snake");
    }
}
