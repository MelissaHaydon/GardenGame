using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using VIDE_Data;

public class Jae_VIDEPlayerScript : MonoBehaviour
{
    //This script handles player movement and interaction with other NPC game objects

    public string playerName;

    //Reference to our diagUI script for quick access
    public UIManager diagUI;
    //public QuestChartDemo questUI;
    public Animator anim;

    //Stored current VA when inside a trigger
    public VIDE_Assign inTrigger;

    public GameObject attentionBubble;

    public float z;
    public float x;

    public KeyCode upKey;
    public KeyCode downKey;
    public KeyCode leftKey;
    public KeyCode rightKey;
    public KeyCode actionKey;

    public float moveSpeed;
    public bool moving;
    public Vector2 lastMove;

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<VIDE_Assign>() != null)
        {
            inTrigger = other.GetComponent<VIDE_Assign>();
            attentionBubble.SetActive(true);
        }
    }

    void OnTriggerExit()
    {
        inTrigger = null;
        attentionBubble.SetActive(false);
    }

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {

        //Only allow player to move and turn if there are no dialogs loaded
        if (!VD.isActive)
        {
            if (Input.GetKey(upKey))
            {
                z = Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime;
                transform.Translate(0, 0, z);
                moving = true;
            }
            if (Input.GetKey(downKey))
            {
                z = Input.GetAxisRaw("Vertical") * -moveSpeed * Time.deltaTime;
                transform.Translate(0, 0, -z);
                moving = true;
            }
            if (Input.GetKey(leftKey))
            {
                x = Input.GetAxisRaw("Horizontal") * -moveSpeed * Time.deltaTime;
                transform.Translate(-x, 0, 0);
                moving = true;
            }
            if (Input.GetKey(rightKey))
            {
                x = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;
                transform.Translate(x, 0, 0);
                moving = true;
            }

            if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
            {
                lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), lastMove.y);
            }

            if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
            {
                lastMove = new Vector2(lastMove.x, Input.GetAxisRaw("Vertical"));
            }

            if (!Input.GetKey(upKey) && !Input.GetKey(downKey) && !Input.GetKey(leftKey) && !Input.GetKey(rightKey))
            {
                moving = false;
            }

            //if (Input.GetKeyDown(leftKey))
            //{
            //    if (!GetComponent<SpriteRenderer>().flipX)
            //    {
            //        GetComponent<SpriteRenderer>().flipX = true;
            //    }
            //}

            //if (Input.GetKeyDown(rightKey))
            //{
            //    if (GetComponent<SpriteRenderer>().flipX)
            //    {
            //        GetComponent<SpriteRenderer>().flipX = false;
            //    }
            //}

            if (lastMove.x > 0 && GetComponent<SpriteRenderer>().flipX)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }

            if (lastMove.x < 0 && !GetComponent<SpriteRenderer>().flipX)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
        }

        //Interact with NPCs when pressing E
        if (Input.GetKeyDown(actionKey))
        {
            TryInteract();
        }

        anim.SetBool("Moving", moving);
    }

    //Casts a ray to see if we hit an NPC and, if so, we interact
    void TryInteract()
    {
        /* Prioritize triggers */

        if (inTrigger)
        {
            diagUI.Interact(inTrigger);
            return;
        }

        /* If we are not in a trigger, try with raycasts */

        //RaycastHit rHit;

        //if (Physics.Raycast(transform.position, transform.forward, out rHit, 2))
        //{
        //    //Lets grab the NPC's VIDE_Assign script, if there's any
        //    VIDE_Assign assigned;
        //    if (rHit.collider.GetComponent<VIDE_Assign>() != null)
        //        assigned = rHit.collider.GetComponent<VIDE_Assign>();
        //    else return;

        //    if (assigned.alias == "QuestUI")
        //    {
        //        questUI.Interact(); //Begins interaction with Quest Chart
        //    }
        //    else
        //    {
        //        diagUI.Interact(assigned); //Begins interaction
        //    }
        //}
    }
}
