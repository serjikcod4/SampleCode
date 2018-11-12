using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastPlatform : MonoBehaviour {

    public float distance;
    
    private CreatePlatformsController createPlatformsController;
    private RaycastHit hit;
    private bool isRayCast = true;
    private int blockLayerMask = 9;
    private int maxDistanceRayCast = 10;

    private void Start()
    {
        createPlatformsController = FindObjectOfType<CreatePlatformsController>();
    }

    private void Update()
    {
        Ray rightRay = new Ray(transform.position, Vector3.right);
        
        if (Physics.Raycast(rightRay, out hit, maxDistanceRayCast, blockLayerMask) && isRayCast)
        {
            distance = hit.distance;
            createPlatformsController.distance = distance;
            createPlatformsController.InstSingleBlock();
            isRayCast = false;
        }
    }
}
