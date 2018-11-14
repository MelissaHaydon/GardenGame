using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TermCatch : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, speed,0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, -speed, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(speed, 0, 0);
        }
        Vector3 playerpos = transform.position;
        playerpos.y = Mathf.Clamp(transform.position.y, -4, 4);
        playerpos.x = Mathf.Clamp(transform.position.x, -7, 7);
        transform.position = playerpos;
    }
}
