using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour {

    public Slider volumeS;
    public float volume;
    public Text volumeT;

    public Dropdown resolution;
    public bool fullScreen;

	// Use this for initialization
	void Start () {
        volumeS.value = 50;
        fullScreen = false;
	}
	
	// Update is called once per frame
	void Update () {
        volume = Mathf.RoundToInt(volumeS.value);
        volumeT.text = "" + volume;
        AudioListener.volume = volume;

        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log(AudioListener.volume);
        }
	}

    public void FullScreen()
    {
        fullScreen = !fullScreen;
    }

    public void ScreenRes()
    {
        if (resolution.value == 0 && fullScreen == false)
        {
            Screen.SetResolution(1024, 768, false);
        }
        if (resolution.value == 0 && fullScreen == true)
        {
            Screen.SetResolution(1024,768, true);
        }
        if (resolution.value == 1 && fullScreen == true)
        {
            Screen.SetResolution(1366, 768, true);
        }
        if (resolution.value == 1 && fullScreen == false)
        {
            Screen.SetResolution(1366, 768, false);
        }
        if (resolution.value == 2 && fullScreen == true)
        {
            Screen.SetResolution(960, 640, true);
        }
        if (resolution.value == 2 && fullScreen == false)
        {
            Screen.SetResolution(960, 640, false);
        }
        if (resolution.value == 3 && fullScreen == true)
        {
            Screen.SetResolution(1920, 1080, true);
        }
        if (resolution.value == 3 && fullScreen == false)
        {
            Screen.SetResolution(1920, 1080, false);
        }
    }
}
