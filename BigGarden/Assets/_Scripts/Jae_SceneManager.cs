using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jae_SceneManager : MonoBehaviour {

    public Animator transitionAnim;
    public string sceneName;
    public Jae_VIDEPlayerScript player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GoToBeeGame()
    {
        sceneName = "Maze";
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
