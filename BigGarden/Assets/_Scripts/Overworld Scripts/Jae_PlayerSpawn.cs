using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jae_PlayerSpawn : MonoBehaviour {

    public Jae_GameManager gameManager;
    public Jae_VIDEPlayerScript player;
    public Vector3[] spawnPointArray;

	// Use this for initialization
	void Start () {
        gameManager = FindObjectOfType<Jae_GameManager>();
        player = FindObjectOfType<Jae_VIDEPlayerScript>();
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
        player.transform.position = spawnPointArray[2];
    }
}
