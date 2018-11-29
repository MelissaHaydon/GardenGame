using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsData : MonoBehaviour {

    private static int resolution, fullScreen;
    private static float volume = 50;

    public static float Volume
    {
        get
        {
            return volume;
        }
        set
        {
            volume = value;
        }
    }

    public static int Resolution
    {
        get
        {
            return resolution;
        }
        set
        {
            resolution = value;
        }
    }
    public static int FullScreen
    {
        get
        {
            return fullScreen;
        }
        set
        {
            fullScreen = value;
        }
    }
}
