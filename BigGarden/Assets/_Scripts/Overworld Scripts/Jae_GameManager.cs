using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jae_GameManager : MonoBehaviour {

    public Jae_VIDEPlayerScript player;
    public GameObject pauseMenu;
    public GameObject options;
    public GameManagerDance danceManager;
    public GameObject goodPresent;
    public GameObject badPresent;
    public bool danceCleared;
    public bool fishCleared;
    public GameObject charToClear;
    public ParticleSystem vanishPartSys;
    public Jae_AudioManager audioManager;
    public bool furnaceHot;

    private void Awake()
    {
        danceManager = FindObjectOfType<GameManagerDance>();
        if (danceManager == null)
        {
            return;
        }
    }

    // Use this for initialization
    void Start () {
        if (danceManager != null && danceManager.clearedGame)
        {
            danceCleared = true;
            if (/*danceManager.goodGift &&*/ !danceManager.finishedFishing)
            {
                //GameObject.Find("Bee_NPC").GetComponent<Jae_SpawnItem>().InstantiateItem();
                Instantiate(goodPresent, new Vector3(-21.8f, 0, 9.8f), Quaternion.identity);
                audioManager.PlaySound("Hackbeat");
            }
            //else if (!danceManager.goodGift && !danceManager.finishedFishing)
            //{
            //    Instantiate(badPresent, new Vector3(-21.8f, -0.8f, 9.8f), Quaternion.identity);
            //    //GameObject.Find("Bee_NPC").GetComponent<Jae_SpawnItem>().InstantiateItem();
            //}
        }
        if (danceManager != null && danceManager.finishedFishing)
        {
            fishCleared = true;
            //Instantiate(goodPresent, new Vector3(-21.8f, 0, 9.8f), Quaternion.identity); //Instantiate Saved Termites
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

    public void FurnaceHot()
    {
        furnaceHot = true;
    }

    public void GoToPauseButton()
    {
        pauseMenu.SetActive(true);
        player.canPlay = false;
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
        player.canPlay = true;
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

    public void WaspBeGone()
    {
        charToClear = GameObject.Find("Wasp_NPC");
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

    public void StinkbugBeGone()
    {
        charToClear = GameObject.Find("StinkbugJacob_NPC");
        RemoveCharacter();
        charToClear = GameObject.Find("StinkbugMatt_NPC");
        RemoveCharacter();
    }

    public void LadyThugsBeGone()
    {
        charToClear = GameObject.Find("LadyThugLeader_NPC");
        RemoveCharacter();
        charToClear = GameObject.Find("LadyThugFile_NPC");
        RemoveCharacter();
        charToClear = GameObject.Find("LadyThugRead_NPC");
        RemoveCharacter();
    }

    public void PrayingMantisBeGone()
    {
        charToClear = GameObject.Find("PrayingMantis_NPC");
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

    public void RemoveTermites()
    {
        GameObject[] termiteArray;
        termiteArray = GameObject.FindGameObjectsWithTag("Termite");
        vanishPartSys.transform.position = termiteArray[0].transform.position;
        vanishPartSys.Play();
        audioManager = Jae_AudioManager.instance;
        audioManager.PlaySound("Poof");
        for (int i = 0; i < termiteArray.Length; i++)
        {
            termiteArray[i].gameObject.SetActive(false);
        }
    }
}
