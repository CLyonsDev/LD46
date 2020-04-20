using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCenterOfMass : MonoBehaviour
{
    private Rigidbody rb;
    public Transform Location;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = Location.localPosition;
    }
}
