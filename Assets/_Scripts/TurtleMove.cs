using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleMove : MonoBehaviour {

    public Camera cam;
    public GameObject player;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	    if(this.transform.childCount >= 1)
        {
            if (Input.GetKey(KeyCode.W))
            {
               this.transform.position += cam.transform.forward;
            }
            if (Input.GetKey(KeyCode.S))
            {
                this.transform.position -= cam.transform.forward;
            }
            if (Input.GetKey(KeyCode.A))
            {
                this.transform.eulerAngles += new Vector3(0, 0, 2);
            }
            if (Input.GetKey(KeyCode.D))
            {
                this.transform.eulerAngles += new Vector3(0, 0, -2);
            }

            player.transform.position = this.transform.position + new Vector3(0, 3, 0);
        }
	}
}
