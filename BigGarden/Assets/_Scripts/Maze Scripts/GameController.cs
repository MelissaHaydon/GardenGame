using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    private static bool created = false;
    public static GameController instance = null;
    public Jae_SceneManager sceneManager;
    //public PlayerController player;

    float timeLeft = 60.0f;
    float timeRounded;
    public Text timerText;

    public GameObject bee;
    public Text pollenCount;
    public Text message;
    public Text timeUp;
    public Animator heldAnimator;
    int pollenTotal = 0;
    int pollenHeld;

    public static bool goodGift;
    public bool clearedGame;

    void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(gameObject);
            created = true;
        }
        Time.timeScale = 1;
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        pollenCount.text = "Pollen Stored: " + 0;
        message.text = "";
        timerText.text = "";
    }

    // Update is called once per frame
    void Update () {
        
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
        }
        if (timeLeft <= 0)
        {
            bee.GetComponent<PlayerController>().speed = 0;
            timeUp.gameObject.SetActive(true);
            clearedGame = true;
            if (timerText != null)
            {
                timerText.text = "0";
            }
            if (pollenTotal >= 20)
            {
                goodGift = true;
            }
            sceneManager.GoToZoneOne();
        }
        pollenHeld = bee.GetComponent<PlayerController>().pollenHeld;
        if (pollenHeld >= 5)
        {
            message.text = "Maximum Pollen Held Return to the Hive";
            heldAnimator.SetTrigger("MaxPollen");
        }
        else
        {
            message.text = "Pollen Held: " + pollenHeld.ToString();
        }
        timeRounded = Mathf.Round(timeLeft);
        timerText.text = timeRounded.ToString();

	}

    public void AddPollen(int pollen)
    {
        pollenTotal += pollen;
        pollenCount.text = "Pollen Stored: " + pollenTotal.ToString();
    }

}
