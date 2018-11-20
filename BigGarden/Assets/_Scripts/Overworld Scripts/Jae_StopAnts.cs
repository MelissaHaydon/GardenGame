using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jae_StopAnts : MonoBehaviour {

    AntMovement[] antArray;

	// Use this for initialization
	void Start () {
        antArray = FindObjectsOfType<AntMovement>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartDancing()
    {
        for (int i = 0; i < antArray.Length; i++)
        {
            antArray[i].speed = 0;
        }
    }

    public void RunAway()
    {
        for (int i = 0; i < antArray.Length; i++)
        {
            antArray[i].gameObject.SetActive(false);
        }
    }

    public void AntGoAway()
    {
        GameObject.Find("Ant_NPC").SetActive(false);
    }
}
