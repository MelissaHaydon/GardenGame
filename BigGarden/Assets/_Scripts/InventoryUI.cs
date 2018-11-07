using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour {

    public bool[] isFull;
    public GameObject[] invSlot;
    public int[] itemNum;
    public string[] itemName;
    public Text[] itemAmount;
    public Dictionary<string, int> itemDict;


    // Use this for initialization
    void Start ()
    {
        itemDict = new Dictionary<string, int>();
    }
    private void Update()
    {
        for (int i = 0; i < invSlot.Length; i++)
        {
            itemAmount[i].text = "" + itemNum[i];
        }
    }
}
