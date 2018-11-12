using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_Instant : MonoBehaviour {

    public GameObject BG;
    public Score score;
    public bool isInstant;

    private GameObject[] BGs;

    private void Update()
    {
        if(score.score % 2 == 1 && isInstant)
        {
            BGs = GameObject.FindGameObjectsWithTag("BG");
            Instantiate(BG, new Vector3(BGs[BGs.Length - 1].transform.position.x + 26.97f, BGs[BGs.Length - 1].transform.position.y, 0) , Quaternion.identity);
            isInstant = false;
        }
    }
}
