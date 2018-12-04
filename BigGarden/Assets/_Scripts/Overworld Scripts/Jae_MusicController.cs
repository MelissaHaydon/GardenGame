using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jae_MusicController : MonoBehaviour {

    private static bool created = false;
    public static Jae_MusicController instance = null;

    public AudioSource[] musicTracks;

    public int currentTrack;

    public bool musicCanPlay;

    // Use this for initialization
    void Start () {
        if (!created)
        {
            DontDestroyOnLoad(gameObject);
            created = true;
        }
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {
		if (musicCanPlay)
        {
            if (!musicTracks[currentTrack].isPlaying)
            {
                musicTracks[currentTrack].Play();
            }
        } else
        {
            musicTracks[currentTrack].Stop();
        }
	}

    public void SwitchTrack(int newTrack)
    {
        if (!musicTracks[currentTrack].isPlaying)
        {
            musicTracks[currentTrack].Stop();
            currentTrack = newTrack;
            musicTracks[currentTrack].Play();
        }
    }
}
