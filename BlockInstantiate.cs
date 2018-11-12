using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockInstantiate : MonoBehaviour {

    public GameObject blockGameObject;
    public bool isInstantiate;

    private BlockCreatorContoller blockCreatorContoller;

    private void Start()
    {
        blockCreatorContoller = FindObjectOfType<BlockCreatorContoller>();
    }

    private void Update()
    {
        if (isInstantiate)
        {
            var inst = Instantiate(blockGameObject, transform.position, Quaternion.identity);
            inst.transform.parent = transform;
            inst.GetComponent<Rigidbody>().useGravity = false;
            blockCreatorContoller.ReferenceToBlock();
            isInstantiate = false;
        }
    }
}
