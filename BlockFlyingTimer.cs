using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockFlyingTimer : MonoBehaviour {

    public bool isFly;
    public Animator gameOverAnim;
    public ScoreGameOver ScoreGameOver;
    public GoldenCubeScore goldenCubeScore;
    public float blockFlyingTimer;

    private BlockResetTransform blockResetTransform;
    private PogruzhikMoveController pogruzhikMoveController;
    private BlockCreatorContoller blockCreatorContoller;

    private void Start()
    {
        blockResetTransform = FindObjectOfType<BlockResetTransform>();
        pogruzhikMoveController = FindObjectOfType<PogruzhikMoveController>();
        blockCreatorContoller = FindObjectOfType<BlockCreatorContoller>();
    }

    private void Update()
    {

        if (isFly)
        {
            blockFlyingTimer += Time.deltaTime;
            if (blockFlyingTimer >= 3)
            {
                //gameOverAnim.SetBool("showAnim", true);
                ScoreGameOver.ReloadScore();
                blockResetTransform.isResetTransform = true;
                pogruzhikMoveController.isMoveToPosRight = true;
                blockCreatorContoller.isTapUPFirst = false;
                blockCreatorContoller.isCanChangeBlockScale = true;
                blockFlyingTimer = 0;
                goldenCubeScore.DeductGoldenCubeScore();
                isFly = false;
            }
        }
    }
}
