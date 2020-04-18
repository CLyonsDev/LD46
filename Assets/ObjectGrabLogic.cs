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

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.parent.CompareTag("Pickup"))
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
            Destroy(grabbedObject.GetComponent<Rigidbody>());
            grabbedObject.SetParent(this.transform.parent);
        }
    }

    public void Release()
    {
        if (grabbedObject != null)
        {
            //Rigidbody rb = grabbedObject.GetComponent<Rigidbody>();
            //rb.useGravity = true;
            grabbedObject.gameObject.AddComponent<Rigidbody>();
            grabbedObject.SetParent(null);
            Vector3 newVelocity = new Vector3(carRB.velocity.x, 0, carRB.velocity.z);
            grabbedObject.GetComponent<Rigidbody>().interpolation = RigidbodyInterpolation.Interpolate;
            grabbedObject.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
            grabbedObject.GetComponent<Rigidbody>().AddForce(newVelocity, ForceMode.VelocityChange);
            grabbedObject = null;
        }
    }
}
