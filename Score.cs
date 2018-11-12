using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour {

    public Text textScore;
    public Animator animLevel_2;
    public Animator animLevel_3;
    public Sounds sounds;
    public int score;

    private int numberOfScene;
    private bool isLevel_1Complete = true;
    private bool isLevel_2Complete = true;

    private void Start()
    {
        numberOfScene = Application.loadedLevel;
    }

    private void Update()
    {      
        if (score >= 12 && numberOfScene==0 && isLevel_1Complete)
        {
            animLevel_2.SetBool("isShow", true);
            Time.timeScale = 0;
            PlayerPrefs.SetInt("level", 2);
            sounds.LevelVictoryAudio();
            isLevel_1Complete = false;
        }

        if(score >= 20 && numberOfScene==1 && isLevel_2Complete)
        {
            animLevel_3.SetBool("isShow", true);
            Time.timeScale = 0;
            PlayerPrefs.SetInt("level", 3);
            sounds.LevelVictoryAudio();
            isLevel_2Complete = false;
        }
    }

    public void AddScore()
    {
        score += 1;
        textScore.text = score.ToString();
    }
}
