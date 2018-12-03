using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSetUp : MonoBehaviour {
    
    public GameManager fishingManager;
    private Animator furnaceAnim;
    public GameObject[] charsToDespawn;
    public GameObject termiteGroup;
    public GameObject drowningTermites;

	// Use this for initialization
	void Start () {
        //SetUp();
        termiteGroup.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetUp()
    {
        furnaceAnim = GameObject.Find("Furnace_NPC").GetComponent<Animator>();
        Jae_SpawnItem antField = GameObject.Find("AntField_NPC").GetComponent<Jae_SpawnItem>();
        termiteGroup = GameObject.Find("TermiteGroup_Alive");
        drowningTermites = GameObject.Find("TermiteGroup_Drowning");
        //fishingManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        //if (fishingManager == null)
        //{
            //return;
        //}
        //if (fishingManager != null && fishingManager.finishedFishing)
        //{
            furnaceAnim.SetTrigger("FireIncrease");
            for (int i = 0; i < charsToDespawn.Length; i++)
            {
                charsToDespawn[i].gameObject.SetActive(false);
                //return;
            }
            antField.InstantiateItem();
        //}
        termiteGroup.SetActive(true);
        drowningTermites.SetActive(false);
        Destroy(GameObject.Find("Pickaxe"));
    }
}
