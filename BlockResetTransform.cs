using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockResetTransform : MonoBehaviour {

    public bool isResetTransform;
    public Transform blockPosition;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (isResetTransform)
        {
            rb.angularVelocity = new Vector3(0, 0, 0);
            rb.velocity = new Vector3(0, 0, 0);
            rb.useGravity = false;
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            transform.localRotation = new Quaternion(0, 0, 0, 0);
            transform.position = blockPosition.position;
            transform.parent = blockPosition;
            isResetTransform = false;
           
        }
    }
}
  