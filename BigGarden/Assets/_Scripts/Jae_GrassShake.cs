using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jae_GrassShake : MonoBehaviour {
    
    private Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetTrigger("ShakeTrig");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetTrigger("ShakeTrig");
        }
    }
}
