using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Options : MonoBehaviour
{

    public Slider volumeS;
    public float volume;
    public Text volumeT;

    public Dropdown resolution;
    public Text resLabel;
    public Toggle fullScreen;

    // Use this for initialization
    void Start()
    {
        volumeS.value = OptionsData.Volume;
        //print(Screen.currentResolution);
        if (OptionsData.FullScreen == 0)
        {
            fullScreen.isOn = false;
        }
        if (OptionsData.FullScreen == 1)
        {
            fullScreen.isOn = true;
        }
        if (OptionsData.Resolution == 0)
        {
            resolution.value = 0;
        }
        if (OptionsData.Resolution == 1)
        {
            resolution.value = 1;
        }
        if (OptionsData.Resolution == 2)
        {
            resolution.value = 2;
        }
        if (OptionsData.Resolution == 3)
        {
            resolution.value = 3;
        }
    }

    public void DoSetup()
    {
        Invoke("Setup", 2);
    }

    void Setup()
    {
        volumeS = GameObject.Find("AudioSlider").GetComponent<Slider>();
        volumeT = GameObject.Find("VolumeText").GetComponent<Text>();
        resolution = GameObject.Find("DropdownRes").GetComponent<Dropdown>();
        fullScreen = GameObject.Find("ToggleFull").GetComponent<Toggle>();
    }

    // Update is called once per frame
    void Update()
    {
        volume = Mathf.RoundToInt(volumeS.value);
        volumeT.text = "" + volume;
        OptionsData.Volume = volume;
        AudioListener.volume = volume / 100;
    }

    public void ScreenRes()
    {
        if (resolution.value == 3 && fullScreen.isOn == false)
        {
            Screen.SetResolution(1024, 768, false);
            OptionsData.Resolution = 3;
            OptionsData.FullScreen = 0;
        }
        if (resolution.value == 3 && fullScreen.isOn == true)
        {
            Screen.SetResolution(1024, 768, true);
            OptionsData.Resolution = 3;
            OptionsData.FullScreen = 1;
        }
        if (resolution.value == 2 && fullScreen.isOn == true)
        {
            Screen.SetResolution(1366, 768, true);
            OptionsData.Resolution = 2;
            OptionsData.FullScreen = 1;
        }
        if (resolution.value == 2 && fullScreen.isOn == false)
        {
            Screen.SetResolution(1366, 768, false);
            OptionsData.Resolution = 2;
            OptionsData.FullScreen = 0;
        }
        if (resolution.value == 0 && fullScreen.isOn == true)
        {
            Screen.SetResolution(1920, 1200, true);
            OptionsData.Resolution = 0;
            OptionsData.FullScreen = 1;
        }
        if (resolution.value == 0 && fullScreen.isOn == false)
        {
            Screen.SetResolution(1920, 1200, false);
            OptionsData.Resolution = 0;
            OptionsData.FullScreen = 0;
        }
        if (resolution.value == 1 && fullScreen.isOn == true)
        {
            Screen.SetResolution(1920, 1080, true);
            OptionsData.Resolution = 1;
            OptionsData.FullScreen = 1;
        }
        if (resolution.value == 1 && fullScreen.isOn == false)
        {
            Screen.SetResolution(1920, 1080, false);
            OptionsData.Resolution = 1;
            OptionsData.FullScreen = 0;
        }
    }
}
