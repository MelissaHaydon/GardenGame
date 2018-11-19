using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jae_SceneManager : MonoBehaviour {

    public Animator transitionAnim;
    public string sceneName;
    public Jae_VIDEPlayerScript player;
    public Jae_CameraTracker jaeCamera;
    public Transform antTarget;
    public Transform playerTransform;

	// Use this for initialization
	void Awake () {
        transitionAnim = GameObject.Find("SceneTransition").GetComponent<Animator>();
        player = GameObject.Find("Player_Sprite").GetComponent<Jae_VIDEPlayerScript>();
        jaeCamera = GameObject.Find("Main Camera").GetComponent<Jae_CameraTracker>();
        antTarget = GameObject.Find("AntTransformPoint").transform;
        playerTransform = player.transform;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeAntCamera()
    {
        jaeCamera.target = antTarget;
        jaeCamera.lookAt = true;
    }

    public void ResetPlayerCam()
    {
        jaeCamera.target = playerTransform;
        jaeCamera.defaultDistance = new Vector3(0, 1.3f, -8);
        jaeCamera.transform.localEulerAngles = new Vector3(0, 0, 0);
        jaeCamera.lookAt = false;
    }

    public void GoToZoneOne()
    {
        sceneName = "Jae_Scene";
        StartCoroutine(LoadScene());
    }

    public void GoToBeeGame()
    {
        sceneName = "Bee Maze";
        StartCoroutine(LoadScene());
    }

    public void ActivateSceneTransition()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneName);
    }
}
