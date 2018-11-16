using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour {


    public GameObject _player;
    public float xMin;
    public float yMin;
    public float xMax;
    public float yMax;
    public float smootheTime = 0.3f;
    private Vector3 velocity = Vector3.zero;



    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Mathf.Clamp(_player.transform.position.x, xMin, xMax);
        float y = Mathf.Clamp(_player.transform.position.y, yMin, yMax);
        gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(x, y, gameObject.transform.position.z), ref velocity, smootheTime);

    }
}
