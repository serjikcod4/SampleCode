using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour {

    private int numberOfScene;

    private void Start()
    {       
        numberOfScene = Application.loadedLevel;
       
        if (PlayerPrefs.GetInt("level") == 1 && numberOfScene != 0)
        {
            LoadLevel_1();
        }
        if (PlayerPrefs.GetInt("level") == 2 && numberOfScene != 1)
        {
            LoadLevel_2();
        }
        if (PlayerPrefs.GetInt("level") == 3 && numberOfScene != 2)
        {
            LoadLevel_3();
        }
    }

    public void LoadLevel_1()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadLevel_2()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadLevel_3()
    {
        SceneManager.LoadScene(2);
      
    }
}
