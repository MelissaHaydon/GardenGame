using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jae_GameManager : MonoBehaviour {

    public Jae_VIDEPlayerScript player;
    public GameObject exitConfirmationScreen;

	// Use this for initialization
	void Start () {
		
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
}
