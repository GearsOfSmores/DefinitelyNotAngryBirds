
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    //make ScoreManager avaible to all classes
    public static ScoreManager instance;

    [SerializeField] Text scoreText;
    [SerializeField] Text highscoreText;

    int score = 0;
    int highscore = 0;
    
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        scoreText.text = score.ToString() + " POINTS!";
        highscoreText.text = "HIGHSCORE = " + highscore.ToString();
    }

    public void AddPoint()
    {
        score += 1;
        scoreText.text = score.ToString() + " POINTS!";
    }
    
}
