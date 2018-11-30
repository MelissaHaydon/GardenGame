using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jae_PlayerSpawn : MonoBehaviour {

    public Jae_GameManager gameManager;
    public Jae_VIDEPlayerScript player;
    public Jae_CameraTracker cameraTracker;
    public Vector3[] spawnPointArray;
    public Animator transitionAnim;
    public int goTo;

    public Transform treeTransform;
    public Transform playerTransform;

    private bool changeToTreeCam;

	// Use this for initialization
	void Start () {
        gameManager = FindObjectOfType<Jae_GameManager>();
        player = FindObjectOfType<Jae_VIDEPlayerScript>();
        cameraTracker = FindObjectOfType<Jae_CameraTracker>();
        treeTransform = GameObject.Find("TrunkTransform").GetComponent<Transform>();
        playerTransform = player.transform;
        transitionAnim = GameObject.Find("SceneTransition").GetComponent<Animator>();
        if (gameManager.mazeCleared && !gameManager.fishCleared)
        {
            SpawnAtBee();
        }
        else if (gameManager.mazeCleared && gameManager.fishCleared)
        {
            SpawnAtTermites();
        }
        else
        {
            SpawnAtStart();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpawnAtStart()
    {
        player.transform.position = spawnPointArray[0];
    }

    public void SpawnAtBee()
    {
        player.transform.position = spawnPointArray[1];
        player.lastMove = new Vector2(-1, -1);
    }

    public void SpawnAtTermites()
    {
        player.transform.position = spawnPointArray[6];
        player.lastMove = new Vector2(-1, 1);
    }

    public void SpawnFromZone2()
    {
        goTo = 2;
        StartCoroutine(MovePlayer());
    }

    public void SpawnFromZone1()
    {
        goTo = 3;
        StartCoroutine(MovePlayer());
    }

    public void SpawnAtZone3()
    {
        goTo = 4;
        StartCoroutine(MovePlayer());
        changeToTreeCam = true;
    }

    public void From3To2()
    {
        goTo = 5;
        StartCoroutine(MovePlayer());
        changeToTreeCam = false;
    }

    IEnumerator MovePlayer()
    {
        player.moveSpeed = 0;
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1);
        player.transform.position = spawnPointArray[goTo];
        if (changeToTreeCam)
        {
            //cameraTracker.target = treeTransform;
        } else
        {
            cameraTracker.target = playerTransform;
        }
        yield return new WaitForSeconds(0.5f);
        transitionAnim.SetTrigger("reset");
        player.moveSpeed = 5;

    }
}
