using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    public static ScoreController instance;
    [SerializeField] private TextMeshProUGUI scoreText, highscoreText;
    public int score { get; private set; }

    private void Awake()
    {
        instance = this;
        highscoreText.text = "Highscore: " + PlayerPrefs.GetInt("HS").ToString();
    }
    private void Start()
    {
        score = SnakeController.initialScore;
    }
    private void Update()
    {
        scoreText.text = score.ToString();
        if (GameplayController.isDead)
        {
            if (score > PlayerPrefs.GetInt("HS"))
            {
                PlayerPrefs.SetInt("HS", score);
                highscoreText.text = highscoreText.text = "Highscore: " + PlayerPrefs.GetInt("HS").ToString();
            }
        }
    }

    public void IncreaseScore()
    {
        score++;
    }
}
