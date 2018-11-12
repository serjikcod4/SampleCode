using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionPlayerwithGoldeCube : MonoBehaviour {

    private GoldenCubeScore goldenCubeScore;
    private Sounds sounds;

    private void Start()
    {
        goldenCubeScore = FindObjectOfType<GoldenCubeScore>();
        sounds = FindObjectOfType<Sounds>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sounds.GoldenCubePickUpAudio();
            goldenCubeScore.AddGoldenCubeScore();
            Destroy(gameObject);
        }
    }
}
