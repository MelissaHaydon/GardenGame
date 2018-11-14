using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jae_FlipNPC : MonoBehaviour {

    public Jae_VIDEPlayerScript player;
    private Animator anim;
    public int playerDirection;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        player = FindObjectOfType<Jae_VIDEPlayerScript>();
	}
	
	// Update is called once per frame
	void Update () {
		if (player.transform.position.x > transform.position.x)
        {
            playerDirection = 1;
        }
        else if (player.transform.position.x < transform.position.x)
        {
            playerDirection = -1;
        }

        anim.SetInteger("PlayerDirection", playerDirection);
	}
}
