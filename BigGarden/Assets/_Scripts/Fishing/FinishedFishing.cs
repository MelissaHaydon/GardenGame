using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishedFishing : MonoBehaviour {

    private static bool created = false;
    public static FinishedFishing instance = null;
    public bool finishedFishingBool;

    private void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(gameObject);
            created = true;
        }
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void FinishedFishingBool()
    {
        finishedFishingBool = true;
    }
}
