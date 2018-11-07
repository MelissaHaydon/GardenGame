using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jae_CameraTracker : MonoBehaviour {

    [SerializeField] Transform target;
    [SerializeField] public Vector3 defaultDistance = new Vector3(0f, 2f, -10f);
    [SerializeField] float distanceDamp;
    [SerializeField] float rotationalDamp;

    //public Transform followTarget;

    //public float speed;
    //public Vector3 offset;

    Transform myT;
    Vector3 velocity = Vector3.one;

	// Use this for initialization
	void Awake () {
        myT = transform;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //Vector3 desiredPosition = followTarget.position + offset;
        //Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, followTarget, )
        //transform.position = smoothedPosition;

        //transform.LookAt(followTarget);
    }

    private void LateUpdate()
    {
        SmoothFollow();
    }

    void SmoothFollow()
    {
        Vector3 toPos = target.position + (target.rotation * defaultDistance);
        Vector3 curPos = Vector3.SmoothDamp(myT.position, toPos, ref velocity, distanceDamp);
        myT.position = curPos;
        //myT.LookAt(target, target.up);
    }
}
