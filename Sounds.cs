using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sounds : MonoBehaviour {

    public AudioSource buttonAudio;
    public AudioSource footstepsAudio;
    public AudioSource collisionWithPlatformAudio;
    public AudioSource pogruzhikAudio;
    public AudioSource pogruzhik_Moving;
    public AudioSource pogruzhikRevers;
    public AudioSource whistle_fallenAudio;
    public AudioSource goldenCubePickUpAudio;
    public AudioSource levelVictoryAudio;
    public AudioSource platformCompleteAudio;
    public AudioSource blockCreationAudio;
    public AudioSource[] collisionsBlock;
   

    private Button[] buttons;

    private void Start()
    {
        buttons = FindObjectsOfType<Button>();
        foreach(var e in buttons)
        {
            e.onClick.AddListener(ButtonAudioPlay);
        }
    }

    public void ButtonAudioPlay()
    {
        if (!buttonAudio.isPlaying)
            buttonAudio.Play();
        
    }

    public void FootstepsAudioPlay()
    {
        if (!footstepsAudio.isPlaying)
            footstepsAudio.Play();
    }

    public void CollisionWithPlatformPlay()
    {
        collisionWithPlatformAudio.Play();
    }

    public void CollisionsBlockPlay()
    {   
        collisionsBlock[Random.Range(0, 2)].Play();
    }

    public void PogruzhikPlay()
    {
        if(!pogruzhikAudio.isPlaying)
        pogruzhikAudio.Play();
    }

    public void PogruzhikMovingAudioPlay()
    {
        if (!pogruzhik_Moving.isPlaying)
        {
            pogruzhik_Moving.Play();
        }
    }

    public void PogruzhikRevers()
    {
        if (!pogruzhikRevers.isPlaying)
        {
            pogruzhikRevers.Play();
        }
    }

    public void WhistleFallenAudioPlay()
    {
        if (!whistle_fallenAudio.isPlaying)
        {
            whistle_fallenAudio.Play();
        }
    }

    public void GoldenCubePickUpAudio()
    {
        if (!goldenCubePickUpAudio.isPlaying)
        {
            goldenCubePickUpAudio.Play();
        }
    }

    public void LevelVictoryAudio()
    {
        if (!levelVictoryAudio.isPlaying)
        {
            levelVictoryAudio.Play();
        }
    }

    public void PlatformCompleteAudioPlay()
    {
        if (!platformCompleteAudio.isPlaying)
        {
            platformCompleteAudio.Play();
        }
    }

    public void BlockCreationAudioPlay()
    {
        
            blockCreationAudio.Play();
        
    }
}
