using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject termiteL;
    public GameObject termiteR;
    public int termChoose;
    private float termheight;
    public int termScore;
    public Text score;
    public float timerF;
    public int timerInt;
    public Text timer;

	// Use this for initialization
	void Start () {
        InvokeRepeating("SpawnTermite", 5, 1f);
	}
	
	// Update is called once per frame
	void Update () {
        timerF = timerF - Time.deltaTime;
        timerInt = Mathf.RoundToInt(timerF);
        timer.text = "" + timerInt;

        score.text = "" + termScore;
	}

    public void SpawnTermite()
    {
        termChoose = Random.Range(0,2);
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
    }
}
