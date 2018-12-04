using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerDance : MonoBehaviour {

    private static bool created = false;
    public static GameManagerDance instance = null;

    public AudioSource theMusic;

    public Jae_AudioManager audioManager;

    public bool startPlaying;

    public BeatScroller theBS;

    public CameraShake cameraShake;
    public GameObject screenFlash;

    public GameObject timeUpText;

    public int currentScore = 0;
    public int scorePerNote = 100;

    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierThresholds;

    public Text scoreText;
    public Text multiText;

    public BeeDance danceScript;
    public BeeDance2 danceScript2;

    public Jae_SceneManager sceneManager;
    public bool clearedGame;
    public bool finishedFishing;

    void Awake()
    {
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

    // Use this for initialization
    void Start () {
        instance = this;

        scoreText.text = "Score: 0";
        currentMultiplier = 1;
        audioManager = Jae_AudioManager.instance;
    }
	
	// Update is called once per frame
	void Update () {
        if (!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                startPlaying = true;
                theBS.hasStarted = true;

                theMusic.Play();
                danceScript.playing = true;
                danceScript2.playing = true;
            }
        }
	}

    public void NoteHit()
    {
        Debug.Log("Hit On Time");

        if (currentMultiplier - 1 < multiplierThresholds.Length)
        {
            multiplierTracker++;

            if (multiplierThresholds[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }
        multiText.text = "Multiplier: x" + currentMultiplier;
        currentScore += scorePerNote * currentMultiplier;
        scoreText.text = "Score: " + currentScore;
        cameraShake.shakeDuration = 0.2f;
        screenFlash.GetComponent<Animator>().SetTrigger("Flash");
    }

    public void NoteMissed()
    {
        Debug.Log("Missed Note");

        currentMultiplier = 1;
        multiplierTracker = 0;

        multiText.text = "Multiplier: x" + currentMultiplier;
    }

    public void EndGame()
    {
        clearedGame = true;
        timeUpText.SetActive(true);
        audioManager.PlaySound("Whistle");
        sceneManager.GoToZoneOne();
    }
}
