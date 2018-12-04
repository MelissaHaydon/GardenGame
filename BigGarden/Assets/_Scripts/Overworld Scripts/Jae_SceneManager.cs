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
    public float sceneDelay;

	// Use this for initialization
	void Start () {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Jae_Scene")
        {
            player = GameObject.Find("Player_Sprite").GetComponent<Jae_VIDEPlayerScript>();
            playerTransform = player.transform;
            jaeCamera = FindObjectOfType<Jae_CameraTracker>();
        }
        transitionAnim = GameObject.Find("SceneTransition").GetComponent<Animator>();
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeAntCamera()
    {
        antTarget = GameObject.Find("AntTransformPoint").transform;
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

    public void PlayGame()
    {
        sceneName = "Jae_Scene";
        PlayerPrefs.DeleteAll();
        if (System.IO.Directory.Exists(Application.dataPath + "/VIDE/saves"))
        {
            System.IO.Directory.Delete(Application.dataPath + "/VIDE/saves", true);
        }
        StartCoroutine(LoadScene());
    }

    public void GoToZoneOne()
    {
        sceneName = "Jae_Scene";
        StartCoroutine(LoadScene());
    }

    public void GoToBeeGame()
    {
        sceneName = "RhythmMiniGamev2";
        StartCoroutine(LoadScene());
    }

    public void GoToFishingGame()
    {
        sceneName = "Fishing";
        Destroy(GameObject.Find("Game Manager"));
        StartCoroutine(LoadScene());
    }

    public void GoToMainMenu()
    {
        sceneName = "MainMenu";
        Destroy(GameObject.FindObjectOfType<GameManagerDance>());
        StartCoroutine(LoadScene());
    }

    public void FinishFishingGame()
    {
        sceneName = "Jae_Scene";
        StartCoroutine(LoadScene());
    }

    public void BeatTheGame()
    {
        sceneName = "The End";
        Destroy(GameObject.FindObjectOfType<GameManagerDance>());
        StartCoroutine(LoadScene());
    }

    public void ActivateSceneTransition()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Jae_Scene")
        {
            sceneDelay = 0f;
        }
        else if (scene.name == "Bee Maze" || scene.name == "RhythmMiniGamev2")
        {
            sceneDelay = 3f;
        }
        else if (scene.name == "MainMenu")
        {
            sceneDelay = 0f;
        }
        else if (scene.name == "Fishing")
        {
            sceneDelay = 2f;
        }

        yield return new WaitForSeconds(sceneDelay);
        transitionAnim = GameObject.Find("SceneTransition").GetComponent<Animator>();
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneName);
    }
}
