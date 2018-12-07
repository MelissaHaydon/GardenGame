﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {

    private SpriteRenderer mySR;
    public Sprite defaultImage;
    public Sprite pressedImage;

    public KeyCode keyToPress;
    public KeyCode secondKey;

	// Use this for initialization
	void Start () {
        mySR = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(keyToPress) || Input.GetKeyDown(secondKey))
        {
            mySR.sprite = pressedImage;
            transform.localScale = new Vector3(0.35f, 0.35f, 0.35f);
        }
        if (Input.GetKeyUp(keyToPress) || Input.GetKeyUp(secondKey))
        {
            mySR.sprite = defaultImage;
            transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        }
	}
}
