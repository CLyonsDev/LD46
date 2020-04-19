using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICar : MonoBehaviour
{
    private bool CanDrive;
    public float speed = 10f;
    private Rigidbody rb;

    private Collider[] colliders;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        colliders = GetComponentsInChildren<Collider>();
    }

    void FixedUpdate()
    {
        if(CanDrive)
        {
            Vector3 targetVec = new Vector3(transform.forward.x, 0, transform.forward.z);
            rb.AddForce(targetVec * speed, ForceMode.Force);
        }
    }

    public void ActivateAI()
    {
        CanDrive = true;

        /*foreach (Collider c in colliders)
        {
            c.enabled = true;
        }*/
    }

    public void DeactivateAI()
    {
        CanDrive = false;

        /*foreach (Collider c in colliders)
        {
            c.enabled = false;
        }*/
    }
}
