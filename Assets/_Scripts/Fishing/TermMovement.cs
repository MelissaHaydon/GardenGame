using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TermMovement : MonoBehaviour {

    public enum Direction { left, right };

    public Direction direction;
    public float speed;
    public GameManager gm;

	// Use this for initialization
	void Start () {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        switch (direction)
        {
            case Direction.left:
                gameObject.transform.position += new Vector3(speed, 0, 0);
                break;
            case Direction.right:
                gameObject.transform.position += new Vector3(-speed, 0, 0);
                break;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.Space))
        {
            gm.termScore++;
            Destroy(gameObject);
        }
    }
}
