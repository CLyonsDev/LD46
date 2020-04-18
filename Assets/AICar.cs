using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICar : MonoBehaviour
{
    public float speed = 10f;
    //public float EngineStrength;
    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 targetVec = new Vector3(transform.forward.x, 0, transform.forward.z);
        rb.AddForce(targetVec * speed, ForceMode.Force);
    }

    public void ActivateAI()
    {

    }

    public void DeactivateAI()
    {

    }
}
