using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jae_EndSnail : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);

        if (transform.position.x >= 150)
        {
            gameObject.SetActive(false);
        }
	}
}
