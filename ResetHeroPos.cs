using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetHeroPos : MonoBehaviour {

    private GameObject[] edgesPositions;

    public void ResetHeroPosition()
    {
        edgesPositions = GameObject.FindGameObjectsWithTag("EdgePosition");
        transform.position = new Vector3(edgesPositions[edgesPositions.Length - 2].transform.position.x,
                                         -2.24f,
                                         edgesPositions[edgesPositions.Length - 2].transform.position.z);

        transform.localRotation = new Quaternion(0, 0, 0, 0);
    }
}
