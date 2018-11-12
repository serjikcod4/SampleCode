using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldenCubeScore : MonoBehaviour {

    public Text textUILifePrewiew;
    public Text scoreText;
    public Animator animatorGameOver;
    public int goldenScore;

    private PlayerMoveController playerMoveController;
    private BlockCreatorContoller blockCreatorContoller;    
    private PogruzhikMoveController pogruzhikMoveController;

    private void Start()
    {
        PlayerPrefs.SetInt("goldenScore", 3);
        goldenScore = PlayerPrefs.GetInt("goldenScore");
        scoreText.text = goldenScore.ToString();
        playerMoveController = FindObjectOfType<PlayerMoveController>();
        blockCreatorContoller = FindObjectOfType<BlockCreatorContoller>();       
        pogruzhikMoveController = FindObjectOfType<PogruzhikMoveController>();
    }

    private void Update()
    {
        if (goldenScore == 0)
        {
            animatorGameOver.SetBool("showAnim", true);
            playerMoveController.enabled = false;
            blockCreatorContoller.enabled = false;
            pogruzhikMoveController.isMoveToPosLeft = false;
            pogruzhikMoveController.isMoveToPosRight = false;
            pogruzhikMoveController.isCanMovePogruzhicktoCameraCenter = false;
            Time.timeScale = 1;       
        }
    }

    public void AddGoldenCubeScore()
    {
        goldenScore += 1;
        PlayerPrefs.SetInt("goldenScore", goldenScore);
        scoreText.text = goldenScore.ToString();
        textUILifePrewiew.text = goldenScore.ToString();
    }

    public void DeductGoldenCubeScore()
    {
        goldenScore -= 1;
        scoreText.text = goldenScore.ToString();
        textUILifePrewiew.text = goldenScore.ToString();
    }

    public void AddRewardGoldenCube()
    {
        goldenScore += 3;
        scoreText.text = goldenScore.ToString();
        textUILifePrewiew.text = goldenScore.ToString();
    }
}
