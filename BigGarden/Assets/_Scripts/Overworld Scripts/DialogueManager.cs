using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour {

    public static DialogueManager instance;
    //public UIManager uiManager;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            if (this != instance)
                Destroy(this.gameObject);
        }

        PlayerPrefs.DeleteAll();
        if (System.IO.Directory.Exists(Application.dataPath + "/VIDE/saves"))
            {
                System.IO.Directory.Delete(Application.dataPath + "/VIDE/saves", true);
            }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
