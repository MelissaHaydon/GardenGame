using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TermCatch : MonoBehaviour {

    public float speed;
    public bool canMove;
    private Rigidbody _rb;

    public bool catching;

	// Use this for initialization
	void Start () {
        canMove = true;
        _rb = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if(canMove == true)
        {
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                transform.position += new Vector3(0, speed, 0);
            }
            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                transform.position += new Vector3(0, -speed, 0);
            }
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                transform.position += new Vector3(-speed, 0, 0);
            }
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                transform.position += new Vector3(speed, 0, 0);
            }
        }
        Vector3 playerpos = transform.position;
        playerpos.y = Mathf.Clamp(transform.position.y, -4, 4);
        playerpos.x = Mathf.Clamp(transform.position.x, -7, 7);
        transform.position = playerpos;

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.E))
        {
            canMove = false;
            Animator netAnim = GameObject.Find("FishingNet_Null").GetComponent<Animator>();
            netAnim.SetTrigger("Swing");
            catching = true;
            Movement();
        }
    }

    public void Movement()
    {
        Invoke("ResetMove", 0.5f);
        _rb.velocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;
    }

    void ResetMove()
    {
        canMove = true;
        catching = false;
    }
}
