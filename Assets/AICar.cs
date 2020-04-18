using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICar : MonoBehaviour
{
    private bool isActive = true;

    public float speed = 10f;
    public float EngineStrength;
    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if(isActive)
        {
            Vector3 targetVec = new Vector3(transform.forward.x, 0, transform.forward.y);
            rb.AddForce(targetVec * speed * EngineStrength, ForceMode.Force);
        }
    }

    public void ActivateAI()
    {

    }

    public void DeactivateAI()
    {

    }
}
