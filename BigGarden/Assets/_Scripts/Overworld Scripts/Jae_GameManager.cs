using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jae_GameManager : MonoBehaviour {

    public Jae_VIDEPlayerScript player;
    public GameObject pauseMenu;
    public GameObject options;
    public GameManager mazeManager;
    public GameObject goodPresent;
    public GameObject badPresent;
    public bool mazeCleared;
    public GameObject spiderNPC;
    public GameObject charToClear;
    public ParticleSystem vanishPartSys;
    public Jae_AudioManager audioManager;

    private void Awake()
    {
        mazeManager = FindObjectOfType<GameManager>();
        if (mazeManager == null)
        {
            return;
        }
    }

    // Use this for initialization
    void Start () {
		if (mazeManager != null && mazeManager.clearedGame)
        {
            mazeCleared = true;
            if (mazeManager.goodGift)
            {
                //GameObject.Find("Bee_NPC").GetComponent<Jae_SpawnItem>().InstantiateItem();
                Instantiate(goodPresent, new Vector3(-21.8f, 0, 9.8f), Quaternion.identity);
            }
            else
            {
                Instantiate(badPresent, new Vector3(-21.8f, -0.8f, 9.8f), Quaternion.identity);
                //GameObject.Find("Bee_NPC").GetComponent<Jae_SpawnItem>().InstantiateItem();
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (pauseMenu.activeSelf == true)
        {
            if (Input.GetKey(player.actionKey) || Input.GetKey(player.upKey) || Input.GetKey(player.downKey) || Input.GetKey(player.leftKey) || Input.GetKey(player.rightKey))
            {
                BackToGame();
            }
        }
        if (pauseMenu.activeSelf == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                GoToPauseButton();
            }
        }
    }

    public void GoToPauseButton()
    {
        pauseMenu.SetActive(true);
        //player.canMove = false;
    }

    public void ToControls()
    {
        pauseMenu.SetActive(false);
        options.SetActive(true);
    }

    public void BackToGame()
    {
        pauseMenu.SetActive(false);
        options.SetActive(false);
        //player.canMove = true;
    }

    public void FurnaceFireUpgrade()
    {
        Animator furnaceAnim = GameObject.Find("Furnace_NPC").GetComponent<Animator>();
        furnaceAnim.SetTrigger("FireIncrease");
    }

    public void SpiderBeGone()
    {
        charToClear = GameObject.Find("Spider_NPC");
        RemoveCharacter();
    }

    public void BeeBeGone()
    {
        charToClear = GameObject.Find("Bee_NPC");
        RemoveCharacter();
    }

    public void FireflyBeGone()
    {
        charToClear = GameObject.Find("Firefly_NPC");
        RemoveCharacter();
    }

    public void SilkwormBeGone()
    {
        charToClear = GameObject.Find("Silkworm_NPC");
        RemoveCharacter();
    }

    public void RemoveCharacter()
    {
        vanishPartSys.transform.position = charToClear.transform.position;
        vanishPartSys.Play();
        audioManager = Jae_AudioManager.instance;
        audioManager.PlaySound("Poof");
        charToClear.SetActive(false);

    }
}
