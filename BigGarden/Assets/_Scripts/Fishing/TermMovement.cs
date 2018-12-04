using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TermMovement : MonoBehaviour {

    public enum Direction { left, right };

    public Direction direction;
    public float speed;
    public GameManagerFish gm;
    public TermCatch catcher;
    public Jae_AudioManager audioManager;

	// Use this for initialization
	void Start () {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerFish>();
        catcher = GameObject.FindGameObjectWithTag("Player").GetComponent<TermCatch>();
        speed = Random.Range(0.03f, 0.1f);
        audioManager = FindObjectOfType<Jae_AudioManager>();
    }

    private void Update()
    {
        switch (direction)
        {
            case Direction.left:
                gameObject.transform.position += new Vector3(speed, 0, 0);
                break;
            case Direction.right:
                gameObject.transform.position += new Vector3(-speed, 0, 0);
                break;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if ((other.tag == "Player" && catcher.catching) || (Input.GetKey(KeyCode.E) && catcher.catching))
        {
            if (!gm.gameOver)
            {
                gm.termScore++;
                gm.score.GetComponent<Animator>().SetTrigger("Update");
                catcher.canMove = false;
                catcher.Movement();
                Destroy(gameObject);
                audioManager.PlaySound("Plop");
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (!gm.gameOver)
            {
                if (!catcher.damageBoost)
                {
                    gm.termScore -= 2;
                    catcher.ParticlePlay();
                    catcher.NetHit();
                }
            }
        }
    }
}
