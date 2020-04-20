using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrangleHeart : MonoBehaviour
{
    public GameObject heartGO;

    public Transform resetTransform;

    private void OnTriggerExit(Collider other)
    {
        if(other.transform.root.gameObject == heartGO)
        {
            Debug.Log("Heart lost! Resetting...");
            heartGO.transform.position = resetTransform.position;
            heartGO.GetComponent<Rigidbody>().velocity = Vector3.zero;
            heartGO.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
    }
}
