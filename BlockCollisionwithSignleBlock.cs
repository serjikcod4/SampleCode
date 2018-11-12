using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCollisionwithSignleBlock : MonoBehaviour {

    public Sounds sounds;

    private PlayerMoveController playerMoveController;
    private BlockCreatorContoller blockCreatorContoller;
    private BlockFlyingTimer blockFlyingTimer;
    private GoldenCubeScore goldenCubeScore;
    
    //Tags
    private string singleBlockTag = "SingleBlock";

    private void Start()
    {
        playerMoveController = FindObjectOfType<PlayerMoveController>();
        blockCreatorContoller = FindObjectOfType<BlockCreatorContoller>();
        blockFlyingTimer = GetComponent<BlockFlyingTimer>();
        goldenCubeScore = FindObjectOfType<GoldenCubeScore>();
    }

    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.collider.CompareTag(singleBlockTag))
        {
            playerMoveController.isCanMovetoEdgePosition = true;
            blockFlyingTimer.isFly = false;
            blockFlyingTimer.blockFlyingTimer = 0;
            sounds.CollisionsBlockPlay();
            sounds.whistle_fallenAudio.Stop();
        }
        if (collision.collider.CompareTag("Platform"))
        {
            sounds.CollisionsBlockPlay();
            sounds.whistle_fallenAudio.Stop();
        }
    }
}
