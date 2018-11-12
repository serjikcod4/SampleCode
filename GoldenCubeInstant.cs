using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenCubeInstant : MonoBehaviour {

    public GameObject goldenCubePrefab;

    private GameObject[] edgePositions;
    private float RndNumber;

    public void InstantGoldenCube()
    {
        RndNumber = Random.Range(0, 100);
        
        edgePositions = GameObject.FindGameObjectsWithTag("EdgePosition");
        var inst = Instantiate(goldenCubePrefab, edgePositions[edgePositions.Length-1].transform.position, Quaternion.identity);
        inst.transform.position = new Vector3(inst.transform.position.x-0.1f, inst.transform.position.y + 0.4f, inst.transform.position.z);
    }
}
