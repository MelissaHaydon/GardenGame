using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class List : MonoBehaviour
{
    public Dictionary<string, int> itemDict;
    public int number = -100;


    private void Start()
    {
        itemDict = new Dictionary<string, int>();

        /*itemDict.Add("Seeds", 5);
        print("Seeds: " + itemDict["Seeds"]);
        itemDict["Seeds"] += 2;
        print(itemDict["Seeds"]);*/
    }
}    
