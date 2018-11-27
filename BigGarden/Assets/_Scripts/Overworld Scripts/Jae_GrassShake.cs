using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jae_GrassShake : MonoBehaviour {
    
    private Animator anim;
    public Jae_AudioManager audioManager;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        audioManager = Jae_AudioManager.instance;
    }
	
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetTrigger("ShakeTrig");
            audioManager.PlaySound("GrassRustle");
        }
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //        anim.SetTrigger("ShakeTrig");
    //        audioManager.PlaySound("GrassRustle");
    //    }
    //}
}
