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

    private void Start()
    {
        Debug.LogError("ResetCar should teleport the player back to the pizza shop parking lot (with all car decorations too)");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.y, 0));
            rb.MovePosition(rb.position + (Vector3.up * RaiseDistance));
        }
    }
}
