using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTimeGoldenCube : MonoBehaviour {

    private float lifeTime = 10f;

    private void Update()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }        
    }
}
