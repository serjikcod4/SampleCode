using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RateShare : MonoBehaviour {

	public void Rate()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.bloomylab.BlockHero");
    }

    public void OnShareClicked()
    {
        // Get the required Intent and UnityPlayer classes.
        AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
        AndroidJavaClass unityPlayerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");

        // Construct the intent.
        AndroidJavaObject intent = new AndroidJavaObject("android.content.Intent");
        intent.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));
        intent.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), "https://play.google.com/store/apps/details?id=com.bloomylab.BlockHero");
        intent.Call<AndroidJavaObject>("setType", "text/plain");

        // Display the chooser.
        AndroidJavaObject currentActivity = unityPlayerClass.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaObject chooser = intentClass.CallStatic<AndroidJavaObject>("createChooser", intent, "Share");
        currentActivity.Call("startActivity", chooser);
    }
}
