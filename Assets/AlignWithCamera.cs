using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignWithCamera : MonoBehaviour
{
    private Transform cameraTransform;

    private float LerpRate = 8.5f;

    // Start is called before the first frame update
    void Awake()
    {
        cameraTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 finalDest = new Vector3(cameraTransform.position.x, transform.position.y, cameraTransform.position.z);

        Quaternion targetRot = Quaternion.LookRotation(transform.position - finalDest);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, LerpRate * Time.deltaTime);
    }
}