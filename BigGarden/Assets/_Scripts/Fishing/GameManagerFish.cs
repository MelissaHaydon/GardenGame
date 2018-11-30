using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerFish : MonoBehaviour {

    public GameObject termiteL;
    public GameObject termiteR;
    public GameObject obstacle;
    public int termChoose;
    private float termheight;
    public int termScore;
    public Text score;
    public float timerF;
    public int timerInt;
    public Text timer;
    public Text timeUpText;

    public int termMissed;
    public Text missedTerms;

    public Jae_SceneManager sceneManager;
    public GameManager finishedFishing;

    public bool gameOver;

	// Use this for initialization
	void Start () {
        InvokeRepeating("SpawnTermite", 5, 1f);
        sceneManager = FindObjectOfType<Jae_SceneManager>();
        finishedFishing = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if (timerF >= 0)
        {
            timerF = timerF - Time.deltaTime;
            timerInt = Mathf.RoundToInt(timerF);
            timer.text = "" + timerInt;
        }
        
        if (timerF < 0)
        {
            timerF = 0;
            timerInt = 0;
            finishedFishing.finishedFishing = true;
            sceneManager.FinishFishingGame();
            timeUpText.gameObject.SetActive(true);
        }

        score.text = "Score: " + termScore;
        missedTerms.text = "" + termMissed;

        if(termScore < 0)
        {
            termScore = 0;
        }
	}

    public void SpawnTermite()
    {
        termChoose = Random.Range(0,3);
        if(termChoose == 0)
        {
            termheight = Random.Range(-4f, 4f);
            Instantiate(termiteL, new Vector3(-10, termheight, 0), Quaternion.identity);
        }
        if(termChoose == 1)
        {
            termheight = Random.Range(-4f, 4f);
            Instantiate(termiteR, new Vector3(10, termheight, 0), Quaternion.identity);
        }
        if (termChoose == 2)
        {
            termheight = Random.Range(-4f, 4f);
            Instantiate(obstacle, new Vector3(10, termheight, 0), Quaternion.identity);
        }
    }
}
