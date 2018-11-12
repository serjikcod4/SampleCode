using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreGameOver : MonoBehaviour {

    public Score score;
    public Text scoreGameOver;
    public Text bestGameOver;

    private int bestScore;

    private void Start()
    {
        bestScore = PlayerPrefs.GetInt("bestScore");
    }

    public void ReloadScore()
    {
        if (score.score > bestScore)
        {
            bestScore = score.score;
            PlayerPrefs.SetInt("bestScore", bestScore);
        }
        scoreGameOver.text = score.score.ToString();
        bestGameOver.text = bestScore.ToString();
    }
}
