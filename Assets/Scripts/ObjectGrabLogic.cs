using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrabLogic : MonoBehaviour
{
    [SerializeField]
    private Transform pickupCandidate;

    [SerializeField]
    private Transform grabbedObject;

    public Rigidbody carRB;

    private VelocityTracker vel;

    public float HealthRestoredOnSqueeze = 15;

    private void Awake()
    {
        vel = GetComponentInParent<VelocityTracker>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.root.CompareTag("Pickup"))
            pickupCandidate = other.transform.root;
    }

    private void OnTriggerExit(Collider other)
    {
        if(pickupCandidate != null && other.transform.parent.CompareTag("Pickup"))
        {
            if (other.transform.root.name == pickupCandidate.name)
            {
                pickupCandidate = null;
            }
        }

    }

    public void Grab()
    {
        if (grabbedObject == null && pickupCandidate != null)
        {
            grabbedObject = pickupCandidate;
            //Rigidbody rb = grabbedObject.GetComponent<Rigidbody>();
            //rb.useGravity = false;
            //Destroy(grabbedObject.GetComponent<Rigidbody>());
            //grabbedObject.SetParent(this.transform.parent);
            grabbedObject.GetComponent<PhysicsObject>().AttachToTransform(this.transform);
        }
    }

    public void Release()
    {
        if (grabbedObject != null)
        {
            Rigidbody rb = grabbedObject.GetComponent<Rigidbody>();
            grabbedObject.GetComponent<PhysicsObject>().Detatch();
            grabbedObject = null;
        }
    }

    public void Squeeze()
    {
        if(grabbedObject != null)
        {
            if(grabbedObject.GetComponent<HeartHealth>() != null)
            {
                grabbedObject.GetComponent<HeartHealth>().AddHealth(HealthRestoredOnSqueeze);
                // TODO: Cooldown between squeezes (have to do it multiple times)
            }
        }
    }
}
