using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCheck : MonoBehaviour {

    private InventoryUI inventory;
    public string checkName;
    public int checkNum;
    public GameObject item;

	// Use this for initialization
	void Start () {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<InventoryUI>();
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            for (int i = 0; i < inventory.invSlot.Length; i++)
            {
                if (inventory.itemName[i] == checkName && inventory.itemNum[i] == checkNum)
                {
                    Debug.Log("Hey");
                    GameObject.Destroy(inventory.invSlot[i].transform.GetChild(1).gameObject);
                    inventory.itemNum[i] = 0;
                    inventory.isFull[i] = false;
                    inventory.itemDict.Remove(inventory.itemName[i]);
                    inventory.itemAmount[i].gameObject.SetActive(false);
                    inventory.itemName[i] = null;
                    break;
                }
            }
        }
    }
}
