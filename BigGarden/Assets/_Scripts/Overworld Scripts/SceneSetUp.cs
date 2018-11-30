using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSetUp : MonoBehaviour {

    public AntMovement[] antArray;
    public FinishedFishing fishingManager;
    private Animator furnaceAnim;
    public GameObject[] charsToDespawn;

	// Use this for initialization
	void Start () {
        SetUp();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetUp()
    {
        furnaceAnim = GameObject.Find("Furnace_NPC").GetComponent<Animator>();
        antArray = FindObjectsOfType<AntMovement>();
        Jae_SpawnItem antField = GameObject.Find("AntField_NPC").GetComponent<Jae_SpawnItem>();
        fishingManager = GameObject.Find("ClearedFish").GetComponent<FinishedFishing>();
        if (fishingManager != null && fishingManager.finishedFishingBool)
        {
            furnaceAnim.SetTrigger("FireIncrease");
            for (int i = 0; i < charsToDespawn.Length; i++)
            {
                charsToDespawn[i].gameObject.SetActive(false);
                //return;
            }
            for (int i = 0; i < antArray.Length; i++)
            {
                antArray[i].gameObject.SetActive(false);
            }
            antField.InstantiateItem();
        }
    }
}
