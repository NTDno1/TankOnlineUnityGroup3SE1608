using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static scoreManager instance;
    public Text scoreText;
    public Text highscoreText;

    int score = 0;
    int highscore = 0;

    public void Awake()
    {
        instance = this;
    }
    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = score.ToString() + " POINTS";
        highscoreText.text = "HIGHSCORE: " + highscore.ToString();

    }

    public void AddPoint()
    {
        score += 1;
        scoreText.text = score.ToString() + " POINTS";
        if( highscore < score)
        PlayerPrefs.SetInt("highscore", score);
    }

    public void AddPointBoss()
    {
        score += 10;
        scoreText.text = score.ToString() + " POINTS";
        if (highscore < score)
            PlayerPrefs.SetInt("highscore", score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
