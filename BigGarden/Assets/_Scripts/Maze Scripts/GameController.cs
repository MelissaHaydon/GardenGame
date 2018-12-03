using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    private static bool created = false;
    public static GameController instance = null;
    public Jae_SceneManager sceneManager;
    public Jae_AudioManager audioManager;
    public GameManager gameManager;
    //public PlayerController player;

    public float timeLeft = 60.0f;
    float timeRounded;
    public Text timerText;

    public GameObject bee;
    public Text pollenCount;
    public Text message;
    public GameObject timeUp;
    public Animator heldAnimator;
    int pollenTotal = 0;
    int pollenHeld;

    //public static bool goodGift;
    //public bool clearedGame;

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

    public void SetUp()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Bee Maze")
        {
            sceneManager = FindObjectOfType<Jae_SceneManager>();
            gameManager = FindObjectOfType<GameManager>();
            timerText = GameObject.Find("timer").GetComponent<Text>();
            bee = GameObject.Find("bee");
            pollenCount = GameObject.Find("pollen total").GetComponent<Text>();
            message = GameObject.Find("message").GetComponent<Text>();
            //timeUp = GameObject.Find("time up").GetComponent<Text>();
            heldAnimator = GameObject.Find("message").GetComponent<Animator>();
            audioManager = Jae_AudioManager.instance;
        }
        pollenCount.text = "Pollen Stored: " + 0;
        message.text = "";
        timerText.text = "";
    }

    private void Start()
    {
        SetUp();
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
            audioManager = Jae_AudioManager.instance;
            audioManager.PlaySound("Whistle");
            timeUp = GameObject.Find("time up");
            timeUp.gameObject.SetActive(true);
            gameManager.clearedGame = true;
            created = false;
            instance = null;
            Destroy(gameObject);
            if (timerText != null)
            {
                timerText.text = "0";
            }
            if (pollenTotal >= 20)
            {
                gameManager.goodGift = true;
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
