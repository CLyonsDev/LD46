using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCar : MonoBehaviour
{
    private Rigidbody rb;

    public float RaiseDistance = 1.5f;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.y, 0));
            rb.MovePosition(Vector3.up * RaiseDistance);
        }
    }
}
