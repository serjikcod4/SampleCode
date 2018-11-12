using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundsOnOff : MonoBehaviour {

    public GameObject soundOn;
    public GameObject soundOff;

    private void Start()
    {
        PlayerPrefs.SetInt("volume", 1);
        if (PlayerPrefs.GetInt("volume") == 1)
        {
            AudioListener.volume = 1;
            soundOn.SetActive(true);
            soundOff.SetActive(false);
        }
        else
        {
            AudioListener.volume = 0;
            soundOn.SetActive(false);
            soundOff.SetActive(true);
        }
    }

    public void SoundsOn()
    {
        AudioListener.volume = 1;
        PlayerPrefs.SetInt("volume", 1);
    }

    public void SoundsOff()
    {
        AudioListener.volume = 0;
        PlayerPrefs.SetInt("volume", 0);
    }
}
