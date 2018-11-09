using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurtleOff : MonoBehaviour {

    public Text deconfirm;
    public GameObject player;
    public GameObject turtle;

    public float x; public float y; public float z;

    private Movement plMove;

    // Use this for initialization
    void Start () {
        plMove = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            deconfirm.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            deconfirm.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update () {

        if (deconfirm.isActiveAndEnabled == true)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                player.transform.parent = null;
                player.transform.position = new Vector3(x, y, z);
                plMove.canMove = true;
                turtle.transform.eulerAngles = new Vector3(90, 0, 0);
            }
        }
    }
}
