
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeMovingActivation : MonoBehaviour {

    private GameObject gameObjectPlayer;
    private PlayerMoveController playerMoveController;

    //Tags Vars
    private string playerTag = "Player";

    private void Start()
    {
        gameObjectPlayer = GameObject.FindGameObjectWithTag(playerTag);
        playerMoveController = gameObjectPlayer.GetComponent<PlayerMoveController>();
    }

    public void EdgeMovingActivationMethod()
    {
        playerMoveController.isMoveToEdgePosition = true;
    }
}
