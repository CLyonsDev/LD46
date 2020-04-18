using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAtMarker : MonoBehaviour
{
    public Vector3Reference Destination;

    public float LerpRate = 5f;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        Vector3 finalDest = new Vector3(Destination.Value.x, transform.position.y, Destination.Value.z);

        Quaternion targetRot = Quaternion.LookRotation(finalDest - transform.position);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, LerpRate * Time.deltaTime);
    }
}
