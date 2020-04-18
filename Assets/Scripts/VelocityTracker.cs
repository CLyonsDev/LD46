using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityTracker : MonoBehaviour
{
    public Vector3 vel;
    private Vector3 prevPos;

    void Awake()
    {
        prevPos = transform.position;
    }

    void FixedUpdate()
    {
        vel = (prevPos - transform.position) / Time.fixedDeltaTime;
        prevPos = transform.position;
    }
}
