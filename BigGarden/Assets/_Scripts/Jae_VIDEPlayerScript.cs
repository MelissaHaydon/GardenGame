using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using VIDE_Data;

public class Jae_VIDEPlayerScript : MonoBehaviour
{
    //This script handles player movement and interaction with other NPC game objects

    public string playerName;

    public Jae_GameManager gameManager;

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
    public KeyCode runKey;

    public float moveSpeed;
    public bool moving;
    public Vector2 lastMove;
    public float moveAnimSpeed;

    public bool isSprinting;
    public ParticleSystem dustParts;

    public Jae_CameraTracker playerCamera;

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

            if (Input.GetKey(runKey) && moving)
            {
                moveSpeed = 9;
                anim.speed = 2;
                playerCamera.defaultDistance.z = -9;
                dustParts.gameObject.SetActive(true);
                if (lastMove.x == 1 && Input.GetKey(rightKey))
                {
                    playerCamera.defaultDistance.x = 2;
                }
                else if (lastMove.x == -1 && Input.GetKey(leftKey))
                {
                    playerCamera.defaultDistance.x = -2;
                }
                else
                {
                    playerCamera.defaultDistance.x = 0;
                }
            }
            else
            {
                moveSpeed = 5;
                anim.speed = 1;
                dustParts.gameObject.SetActive(false);
                playerCamera.defaultDistance.z = -8;
                playerCamera.defaultDistance.x = 0;
            }

        }

        //Interact with NPCs when pressing E
        if (Input.GetKeyDown(actionKey))
        {
            if (!moving)
            {
                TryInteract();
            }
        }

        if (dustParts.gameObject.activeSelf)
        {
            if (Input.GetKeyDown(downKey))
            {
                dustParts.gameObject.transform.localEulerAngles = new Vector3(-25, 0, 0);
            }
            if (Input.GetKeyDown(leftKey))
            {
                dustParts.gameObject.transform.localEulerAngles = new Vector3(-25, 90, 0);
            }
            if (Input.GetKeyDown(upKey))
            {
                dustParts.gameObject.transform.localEulerAngles = new Vector3(-25, 180, 0);
            }
            if (Input.GetKeyDown(rightKey))
            {
                dustParts.gameObject.transform.localEulerAngles = new Vector3(-25, -90, 0);
            }
        }

        if (transform.position.y <= -10)
        {
            transform.position = new Vector3(-11.95f, 0, 0);
        }

        anim.SetBool("Moving", moving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);
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
