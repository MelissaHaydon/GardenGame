using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntMovement : MonoBehaviour
{

    public float sensorLength = 5.0f;
    public float speed = 5.0f;
    float directionValue = 1.0f;
    float turnValue = 0.0f;
    public float turnSpeed = 50.0f;
    Collider myCol;



    void Start()
    {
        myCol = transform.GetComponent<Collider>();
    }

    void Update()
    {
        RaycastHit hit;
        int flag = 0;
        //Right Sensor
        if (Physics.Raycast(transform.position, transform.right, out hit, (sensorLength + transform.localScale.x)))
        {
            if (hit.collider.tag != "Ant")
            {
                if (hit.collider.tag != "Obstacle" || hit.collider == myCol)
                {
                    return;
                }

                turnValue -= 1;
                flag++;
            }
        }

        //Left Sensor
        if (Physics.Raycast(transform.position, -transform.right, out hit, (sensorLength + transform.localScale.x)))
        {
            if (hit.collider.tag != "Ant")
            {
                if (hit.collider.tag != "Obstacle" || hit.collider == myCol)
                {
                    return;
                }

                turnValue += 1;
                flag++;
            }
        }

        //Front Sensor
        if (Physics.Raycast(transform.position, transform.forward, out hit, (sensorLength + transform.localScale.z)))
        {
            if (hit.collider.tag != "Ant")
            {
                if (hit.collider.tag != "Obstacle" || hit.collider == myCol)
                {
                    return;
                }

                if (directionValue == 1.0f)
                {
                    directionValue = -1;
                }
                flag++;
            }
        }

        //Back Sensor
        if (Physics.Raycast(transform.position, -transform.forward, out hit, (sensorLength + transform.localScale.z)))
        {
            if (hit.collider.tag != "Ant")
            {
                if (hit.collider.tag != "Obstacle" || hit.collider == myCol)
                {
                    return;
                }

                if (directionValue == -1.0f)
                {
                    directionValue = 1;
                }
                flag++;
            }
        }
        if (flag == 0)
        {
            turnValue = 0;
        }

        transform.Rotate(Vector3.up * (turnSpeed * turnValue) * Time.deltaTime);

        transform.position += transform.forward * (speed * directionValue) * Time.deltaTime;

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, transform.forward * (sensorLength + transform.localScale.z));
        Gizmos.DrawRay(transform.position, -transform.forward * (sensorLength + transform.localScale.z));
        Gizmos.DrawRay(transform.position, transform.right * (sensorLength + transform.localScale.x));
        Gizmos.DrawRay(transform.position, -transform.right * (sensorLength + transform.localScale.x));
    }

}
