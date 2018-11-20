using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    //private float speed = 0.5f;
    public bool canMove;
    public Camera plCam;

	// Use this for initialization
	void Start () {
        canMove = true;
	}
	
	// Update is called once per frame
	void Update () {
        if(canMove == true)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += plCam.transform.forward;
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.position -= plCam.transform.forward;
            }
            if (Input.GetKey(KeyCode.A))
            {
                this.transform.eulerAngles += new Vector3(0, -2, 0);
            }
            if (Input.GetKey(KeyCode.D))
            {
                this.transform.eulerAngles += new Vector3(0, 2, 0);
            }
        }
    }
}
