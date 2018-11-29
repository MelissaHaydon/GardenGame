using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnaceSetUp : MonoBehaviour {

    //public TERMITEGAMEMANAGER fishingManager;
    private Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        //fishingManager = FindObjectOfType<TERMITEGAMEMANAGER>();
        //if (fishingManager != null && fishingManager.gameCleared)
        {
            anim.SetTrigger("FireIncrease");
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
