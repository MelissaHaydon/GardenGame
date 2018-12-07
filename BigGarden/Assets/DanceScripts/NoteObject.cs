using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour {


    private bool canBePressed;

    public KeyCode keyToPress;
    public KeyCode secondKey;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(keyToPress) || Input.GetKeyDown(secondKey))
        {
            if (canBePressed)
            {
                gameObject.SetActive(false);

                GameManagerDance.instance.NoteHit();
            }
        }
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Activator")
        {
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = false;

            GameManagerDance.instance.NoteMissed();
        }
    }
}
