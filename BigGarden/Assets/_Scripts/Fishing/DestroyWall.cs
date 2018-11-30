using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWall : MonoBehaviour {

    public GameManagerFish gm;

	// Use this for initialization
	void Start () {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerFish>();
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Termite")
        {
            gm.termMissed++;
        }
        if (other.tag != "Player")
        {
            Destroy(other.gameObject);
        }
    }
}
