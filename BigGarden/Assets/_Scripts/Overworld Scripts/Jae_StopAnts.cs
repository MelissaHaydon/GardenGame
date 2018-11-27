using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jae_StopAnts : MonoBehaviour {

    AntMovement[] antArray;
    public Jae_GameManager gameManager;

	// Use this for initialization
	void Start () {
        antArray = FindObjectsOfType<AntMovement>();
        gameManager = FindObjectOfType<Jae_GameManager>();
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
        gameManager.vanishPartSys.transform.position = GameObject.Find("AntTransformPoint").transform.position;
        gameManager.vanishPartSys.transform.position -= new Vector3(0,3,0);
        gameManager.vanishPartSys.Play();
    }

    public void AntGoAway()
    {
        gameManager.charToClear = GameObject.Find("Ant_NPC");
        gameManager.RemoveCharacter();
    }
}
