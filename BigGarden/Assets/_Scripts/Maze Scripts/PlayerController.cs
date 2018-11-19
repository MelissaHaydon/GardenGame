using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float speed = 0.4f;
    Vector2 _dest = Vector2.zero;
    Vector2 _dir = Vector2.zero;
    Vector2 _nextDir = Vector2.zero;

    public ParticleSystem particles;

    [Serializable]
    public class PointSprites
    {
        public GameObject[] pointSprites;
    }

    public PointSprites points;

    public static int killstreak = 0;
    
    public Animator heldAnimator;
    public Animator totalAnimator;
    public Animator beehiveAnimator;

    // script handles
    //private GameGUINavigation GUINav;
    //private GameManager GM;
    //private ScoreManager SM;

    public int pollenHeld;

    // Use this for initialization
    void Start()
    {
        //GM = GameObject.Find("Game Manager").GetComponent<GameManager>();
        //SM = GameObject.Find("Game Manager").GetComponent<ScoreManager>();
        _dest = transform.position;
        pollenHeld = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
                ReadInputAndMove();
                Animate();
    }


    void Animate()
    {
        Vector2 dir = _dest - (Vector2)transform.position;
        GetComponent<Animator>().SetFloat("DirX", dir.x);
        GetComponent<Animator>().SetFloat("DirY", dir.y);
    }

    bool Valid(Vector2 direction)
    {
        // cast line from 'next to pacman' to pacman
        // not from directly the center of next tile but just a little further from center of next tile
        Vector2 pos = transform.position;
        direction += new Vector2(direction.x * 0.45f, direction.y * 0.45f);
        RaycastHit2D hit = Physics2D.Linecast(pos + direction, pos);
        return hit.collider.tag == "flower" || (hit.collider == GetComponent<Collider2D>()) || hit.collider.tag == "beehive" || hit.collider.tag == "wasp";
    }

    public void ResetDestination()
    {
        _dest = new Vector2(15f, 11f);
        GetComponent<Animator>().SetFloat("DirX", 1);
        GetComponent<Animator>().SetFloat("DirY", 0);
    }

    void ReadInputAndMove()
    {
        // move closer to destination
        Vector2 p = Vector2.MoveTowards(transform.position, _dest, speed);
        GetComponent<Rigidbody2D>().MovePosition(p);

        // get the next direction from keyboard
        if (Input.GetAxis("Horizontal") > 0) _nextDir = Vector2.right;
        if (Input.GetAxis("Horizontal") < 0) _nextDir = -Vector2.right;
        if (Input.GetAxis("Vertical") > 0) _nextDir = Vector2.up;
        if (Input.GetAxis("Vertical") < 0) _nextDir = -Vector2.up;

        // if pacman is in the center of a tile
        if (Vector2.Distance(_dest, transform.position) < 0.00001f)
        {
            if (Valid(_nextDir))
            {
                _dest = (Vector2)transform.position + _nextDir;
                _dir = _nextDir;
            }
            else   // if next direction is not valid
            {
                if (Valid(_dir))  // and the prev. direction is valid
                    _dest = (Vector2)transform.position + _dir;   // continue on that direction

                // otherwise, do nothing
            }
        }
    }

    public Vector2 getDir()
    {
        return _dir;
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "flower")
        {
            if (pollenHeld < 5)
            {
                pollenHeld++;
                Destroy(col.gameObject);
                //heldAnimator.SetTrigger("Update");
            }
        }
        else if (col.tag == "beehive")
        {
            if (pollenHeld > 0)
            {
                particles.Play();
                totalAnimator.SetTrigger("Update");
                beehiveAnimator.SetTrigger("Bounce");
            }
            GameController.instance.AddPollen(pollenHeld);
            pollenHeld = 0;
        }
        else if (col.tag == "wasp")
        {
            pollenHeld = 0;
        }
    }

}
