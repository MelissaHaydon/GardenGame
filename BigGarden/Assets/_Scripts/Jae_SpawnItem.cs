﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jae_SpawnItem : MonoBehaviour {

    public GameObject itemToSpawn;
    public Vector3 spawnLocation;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void InstantiateItem()
    {
        Instantiate(itemToSpawn, spawnLocation, Quaternion.identity);
    }
}
