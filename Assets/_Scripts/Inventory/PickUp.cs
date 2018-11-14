﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {

    private InventoryUI inventory;
    public GameObject itemButton;
    public string itemName;

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
                if(inventory.isFull[i] == false && inventory.itemDict.ContainsKey(itemName) == false)
                {
                    inventory.isFull[i] = true;
                    inventory.itemName[i] = itemName;
                    inventory.itemNum[i]++;
                    inventory.itemAmount[i].gameObject.SetActive(true);
                    inventory.itemDict.Add(itemName, 1);
                    Instantiate(itemButton, inventory.invSlot[i].transform, false);             
                    Destroy(gameObject);
                    break;
                }
                else if (inventory.itemDict.ContainsKey(itemName) == true && inventory.itemName[i] == itemName)
                {
                    inventory.itemNum[i]++;
                    inventory.itemDict[itemName] += 1;
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
