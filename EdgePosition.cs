using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgePosition : MonoBehaviour {

    private PlayerMoveController playerMoveController;

    private void Start()
    {
        playerMoveController = FindObjectOfType<PlayerMoveController>();
        playerMoveController.edgePosVector3 = transform.position;
    } 
}
