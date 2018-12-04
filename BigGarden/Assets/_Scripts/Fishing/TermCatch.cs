using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TermCatch : MonoBehaviour {

    public float speed;
    public bool canMove;
    private Rigidbody _rb;
    public ParticleSystem termParts;
    public Jae_AudioManager audioManager;

    public bool catching;
    public bool damageBoost;

	// Use this for initialization
	void Start () {
        canMove = true;
        _rb = this.GetComponent<Rigidbody>();
        audioManager = Jae_AudioManager.instance;
    }
	
	// Update is called once per frame
	void Update () {
        if(canMove == true)
        {
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                transform.position += new Vector3(0, speed * Time.deltaTime, 0);
            }
            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
            }
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
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
            audioManager.PlaySound("Swing");
        }
    }

    public void Movement()
    {
        Invoke("ResetMove", 0.5f);
        _rb.velocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;
        Invoke("DamageBoostOff", 2);
    }

    void ResetMove()
    {
        canMove = true;
        catching = false;
    }

    public void ParticlePlay()
    {
        termParts.Play();
    }

    public void NetHit()
    {
        damageBoost = true;
        Animator netAnim = GameObject.Find("FishingNet_Null").GetComponent<Animator>();
        netAnim.SetTrigger("Hit");
        canMove = false;
        Movement();
        audioManager.PlaySound("Punch");
    }

    public void DamageBoostOff()
    {
        damageBoost = false;
    }
}
