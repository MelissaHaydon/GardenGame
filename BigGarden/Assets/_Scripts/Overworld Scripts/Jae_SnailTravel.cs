using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jae_SnailTravel : MonoBehaviour {

    public Jae_FlipNPC flipNPC;
    public int playerDirection;
    public Animator anim;
    public float moveSpeed;
    public bool moving;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (moving)
        {
            transform.position += new Vector3(moveSpeed, 0, 0) * Time.deltaTime;
        }
	}

    public void StartTravel()
    {
        playerDirection = 1;
        flipNPC.enabled = false;
        anim.SetInteger("PlayerDirection", playerDirection);
        moving = true;
    }
}
