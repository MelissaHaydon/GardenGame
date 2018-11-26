using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jae_PlayerSpawn : MonoBehaviour {

    public Jae_GameManager gameManager;
    public Jae_VIDEPlayerScript player;
    public Vector3[] spawnPointArray;
    public Animator transitionAnim;
    public int goTo;

	// Use this for initialization
	void Start () {
        gameManager = FindObjectOfType<Jae_GameManager>();
        player = FindObjectOfType<Jae_VIDEPlayerScript>();
        transitionAnim = GameObject.Find("SceneTransition").GetComponent<Animator>();
        if (gameManager.mazeCleared)
        {
            SpawnAtBee();
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

    IEnumerator MovePlayer()
    {
        player.moveSpeed = 0;
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1);
        player.transform.position = spawnPointArray[goTo];
        yield return new WaitForSeconds(0.5f);
        transitionAnim.SetTrigger("reset");
        player.moveSpeed = 5;

    }
}
