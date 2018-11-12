using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimScript : MonoBehaviour {

    public bool isSoundsPlay;
    public Sounds sounds;

    private void Update()
    {
        if (isSoundsPlay)
        {
            sounds.CollisionWithPlatformPlay();
        }
    }
}
