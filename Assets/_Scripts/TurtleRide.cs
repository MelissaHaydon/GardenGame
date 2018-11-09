using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurtleRide : MonoBehaviour {

    public Text confirm;
    public GameObject player;
    public GameObject turtle;

    private Movement plMove;

	// Use this for initialization
	void Start () {
        plMove = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
	}

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            confirm.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            confirm.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if(confirm.isActiveAndEnabled == true)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                player.transform.eulerAngles = new Vector3(0, 0, 0);
                player.transform.parent = turtle.transform;
                player.transform.position = turtle.transform.position + new Vector3(0,3,0);
                plMove.canMove = false;
            }
        }
    }
}
