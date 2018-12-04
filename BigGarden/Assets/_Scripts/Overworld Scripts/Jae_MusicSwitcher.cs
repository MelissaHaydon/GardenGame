using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jae_MusicSwitcher : MonoBehaviour {

    private Jae_MusicController mc;
    public int newTrack;

    public bool switchOnStart;

	// Use this for initialization
	void Start () {
        mc = FindObjectOfType<Jae_MusicController>();

        if (switchOnStart)
        {
            mc.SwitchTrack(newTrack);
            //gameObject.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SwitchTracks()
    {
        mc.SwitchTrack(newTrack);
        //gameObject.SetActive(false);
    }
}
