using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jae_GameManager : MonoBehaviour {

    public Jae_VIDEPlayerScript player;
    public GameObject exitConfirmationScreen;
    public GameManager mazeManager;
    public GameObject goodPresent;
    public GameObject badPresent;
    public bool mazeCleared;
    public GameObject spiderNPC;
    public GameObject charToClear;
    public ParticleSystem vanishPartSys;

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
		if (exitConfirmationScreen.activeSelf == true)
        {
            if (Input.GetKey(player.actionKey) || Input.GetKey(player.upKey) || Input.GetKey(player.downKey) || Input.GetKey(player.leftKey) || Input.GetKey(player.rightKey))
            {
                BackToGame();
            }
        }
	}

    public void GoToQuitButton()
    {
        exitConfirmationScreen.SetActive(true);
        //player.canMove = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackToGame()
    {
        exitConfirmationScreen.SetActive(false);
        //player.canMove = true;
    }

    public void SpiderBeGone()
    {
        charToClear = GameObject.Find("Spider_NPC");
        //spiderNPC.SetActive(false);
        RemoveCharacter();
    }

    public void RemoveCharacter()
    {
        vanishPartSys.transform.position = charToClear.transform.position;
        vanishPartSys.Play();
        charToClear.SetActive(false);
    }
}
