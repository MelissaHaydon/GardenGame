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
    public int multiplierLevel;

    public Text scoreText;
    public Text multiText;
    public Text resultText;
    public Text resultMessage;

    public BeeDance danceScript;
    public BeeDance2 danceScript2;

    float notesHit;
    float notesMissed;
    float percentageScore;
    int percentRounded;
    public GameObject goodCombo;
    public GameObject greatCombo;
    public GameObject amazingCombo;

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
        notesHit = 0f;
        notesMissed = 0f;
        percentageScore = 0f;
        percentRounded = 0;
        scoreText.text = "Score: 0";
        currentMultiplier = 1;
        multiplierLevel = 0;
        resultText.text = "";
        resultMessage.text = "";
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
        if (currentMultiplier - 1 < multiplierThresholds.Length)
        {
            multiplierTracker++;

            if (multiplierThresholds[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;
                multiplierLevel++;
                if(multiplierLevel == 1)
                {
                    amazingCombo.SetActive(false);
                    greatCombo.SetActive(false);
                    goodCombo.SetActive(true);
                    goodCombo.GetComponent<Animator>().SetTrigger("Activate");
                }
                else if (multiplierLevel == 2)
                {
                    goodCombo.SetActive(false);
                    greatCombo.SetActive(true);
                    greatCombo.GetComponent<Animator>().SetTrigger("Activate");
                }
                else if (multiplierLevel == 3)
                {
                    greatCombo.SetActive(false);
                    amazingCombo.SetActive(true);
                    amazingCombo.GetComponent<Animator>().SetTrigger("Activate");
                }
            }
        }
        multiText.text = "Multiplier: x" + currentMultiplier;
        currentScore += scorePerNote * currentMultiplier;
        scoreText.text = "Score: " + currentScore;
        cameraShake.shakeDuration = 0.2f;
        screenFlash.GetComponent<Animator>().SetTrigger("Flash");
        notesHit++;
    }

    public void NoteMissed()
    {
        currentMultiplier = 1;
        multiplierLevel = 0;
        multiplierTracker = 0;
        notesMissed++;
        multiText.text = "Multiplier: x" + currentMultiplier;
    }

    public void EndGame()
    {
        clearedGame = true;
        timeUpText.SetActive(true);
        percentageScore = (notesHit / (notesMissed + notesHit)) * 100;
        percentRounded = (int)percentageScore;
        resultText.text = "You got " + percentRounded + "% of notes!";
        if(percentRounded == 100)
        {
            resultMessage.text = "Perfect Score!";
        }
        else if (percentRounded > 50)
        {
            resultMessage.text = "Great Job!";
        }
        else
        {
            resultMessage.text = "Good try!";
        }
        audioManager.PlaySound("Whistle");
        sceneManager.GoToZoneOne();
    }
}
