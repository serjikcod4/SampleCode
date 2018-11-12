using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlatformsController : MonoBehaviour {

    public GameObject[] greyPlatforms;
    public GameObject[] orangePlatforms;
    public GameObject greySingleBlock;
    public float distance;
  
    private GameObject[] allPlatforms;
    private float heightOfRighConorPos = -2.6f - 0.2f;
    private float minOffsetX = 2.5f;
    private float maxOffsetX = 5.0f;
    private float RndDistance;

    public void InstPlat()
    {
        allPlatforms = GameObject.FindGameObjectsWithTag("Platform");
        RndDistance = Random.Range(minOffsetX, maxOffsetX);
        var inst = Instantiate(greyPlatforms[Random.Range(0, 2)], 
                               new Vector3(allPlatforms[allPlatforms.Length - 1].transform.position.x + RndDistance,
                                                         allPlatforms[allPlatforms.Length - 1].transform.position.y,
                                                         allPlatforms[allPlatforms.Length - 1].transform.position.z), 
                               Quaternion.identity);
    }

    public void InstSingleBlock()
    {
        var instSignleBlock = Instantiate(greySingleBlock,
                                         new Vector3(allPlatforms[allPlatforms.Length - 1].transform.position.x + RndDistance / 2,
                                                     -distance + heightOfRighConorPos,
                                                     allPlatforms[allPlatforms.Length - 1].transform.position.z),
                                         Quaternion.identity);
        instSignleBlock.transform.localScale = new Vector3(RndDistance, 1, 1);
    }
}
