using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSetUp : MonoBehaviour {
    
    public GameManagerDance fishingManager;
    private Animator furnaceAnim;
    public GameObject[] charsToDespawn;
    public GameObject[] termiteGroup;
    public GameObject puddleNPC;
    public GameObject snailNPC;
    public UIManager uiMan;

	// Use this for initialization
	void Start () {
        //SetUp();
        termiteGroup = GameObject.FindGameObjectsWithTag("Termite");
        for (int ii = 0; ii < termiteGroup.Length; ii++)
        {
            termiteGroup[ii].gameObject.SetActive(false);
        }
        puddleNPC.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetUp()
    {
        furnaceAnim = GameObject.Find("Furnace_NPC").GetComponent<Animator>();
        Jae_SpawnItem antField = GameObject.Find("AntField_NPC").GetComponent<Jae_SpawnItem>();
        
        furnaceAnim.SetTrigger("FireIncrease");
        for (int i = 0; i < charsToDespawn.Length; i++)
        {
            charsToDespawn[i].gameObject.SetActive(false);
        }
        for (int ii = 0; ii < termiteGroup.Length; ii++)
        {
            termiteGroup[ii].gameObject.SetActive(true);
        }
        antField.InstantiateItem();
        Destroy(GameObject.Find("Pickaxe"));
        puddleNPC.SetActive(true);
        if (uiMan.snailGone)
        {
            snailNPC.SetActive(false);
        }
    }
}
