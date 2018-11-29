using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jae_SpawnItem : MonoBehaviour {

    public GameObject itemToSpawn;
    public Vector3 spawnLocation;

    public Jae_AudioManager audioManager;
    public bool playAudio;
    public string soundName;

    public bool spawnAtPlayer;

	// Use this for initialization
	void Start () {
        audioManager = Jae_AudioManager.instance;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void InstantiateItem()
    {
        if (spawnAtPlayer)
        {
            Instantiate(itemToSpawn, FindObjectOfType<Jae_VIDEPlayerScript>().transform.position, Quaternion.identity);
        } else
        {
            Instantiate(itemToSpawn, spawnLocation, Quaternion.identity);
        }
        if (playAudio)
        {
            audioManager.PlaySound(soundName);
        }
    }
}
