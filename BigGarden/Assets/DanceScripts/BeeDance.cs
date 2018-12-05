using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeDance : MonoBehaviour {

    Animator beeAnim;
    SpriteRenderer bee;
    float timer;
    int timerConverted;
    public bool playing;

    public GameManagerDance gm;

    void Start () {
        playing = false;
        timerConverted = 0;
        timer = 0f;
        bee = GetComponent<SpriteRenderer>();
        beeAnim = GetComponent<Animator>();
        bee.flipX = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (playing)
        {
            timer += Time.deltaTime;
            timerConverted = (int)timer;
            if (timerConverted == 1)
            {
                beeAnim.SetBool("Playing", true);
            }
            else if (timerConverted == 9)
            {
                beeAnim.SetBool("Round", true);
            }
            else if (timerConverted == 14)
            {
                bee.flipX = true;
            }
            else if (timerConverted == 19)
            {
                bee.flipX = false;
            }
            else if (timerConverted == 23)
            {
                bee.flipX = true;
            }
            else if (timerConverted == 28)
            {
                beeAnim.SetBool("Round", false);
                beeAnim.SetBool("CanCan", true);
            }
            else if (timerConverted == 33)
            {
                bee.flipX = false;
            }
            else if (timerConverted == 37)
            {
                bee.flipX = true;
            }
            else if (timerConverted == 42)
            {
                bee.flipX = false;
            }
            else if (timerConverted == 46)
            {
                beeAnim.SetBool("CanCan", false);
                beeAnim.SetBool("Jump", true);
            }
            else if (timerConverted == 65)
            {
                beeAnim.SetBool("Jump", false);
            }
            else if (timerConverted == 74)
            {
                beeAnim.SetBool("Playing", false);
                gm.EndGame();
            }
        }
    }
}
