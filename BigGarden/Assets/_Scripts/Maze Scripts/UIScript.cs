using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour {

	public int high, score;

	public List<Image> lives = new List<Image>(3);

	Text txt_score, txt_high, txt_level;
	
	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{

        // update score text
        score = GameManager.score;

	}


}
