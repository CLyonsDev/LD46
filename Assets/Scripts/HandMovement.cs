﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMovement : MonoBehaviour
{
    [SerializeField]
    private float HandLerpSpeed = 3f;

    [SerializeField]
    private float Sensitivity = 2f;

    public Vector2 HorizontalOffsetClamp;
    public Vector2 VerticalOffsetClamp;
    public Vector2 ForwardBackClamp;
    public float MinDistanceToCamera;   // How close can we get to the camera before it's too close?

    //private Rigidbody rb;
    private bool MoveVertical;

    [SerializeField]
    private Vector3 direction;
    [SerializeField]
    private Vector2 mousePos;

    private ObjectGrabLogic logic;
    private Camera cam;

    // Start is called before the first frame update
    void Awake()
    {
        //rb = GetComponent<Rigidbody>();
        logic = GetComponentInChildren<ObjectGrabLogic>();
        cam = Camera.main;
    }

    private void Start()
    {
        // Game-Jam approved(tm) lazy workaround
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            MoveVertical = true;
        }
        else if(Input.GetMouseButtonUp(1))
        {
            MoveVertical = false;
        }

        if(Input.GetMouseButtonDown(0))
        {
            logic.Grab();
        }else if(Input.GetMouseButtonUp(0))
        {
            logic.Release();
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            logic.Squeeze();
        }

    }

    private void FixedUpdate()
    {
        HandMoveLogic();
    }

    // Update is called once per frame
    void HandMoveLogic()
    {
        mousePos.x = Input.GetAxis("Mouse X");
        mousePos.y = Input.GetAxis("Mouse Y");

        if(MoveVertical == false)
        {
            direction = new Vector3(mousePos.x, 0, mousePos.y);
        }
        else
        {
            direction = new Vector3(mousePos.x, mousePos.y, 0);
        }

        //rb.MovePosition(rb.position + direction * HandLerpSpeed * Time.fixedDeltaTime);
        //rb.transform.Translate(direction * HandLerpSpeed * Time.fixedDeltaTime, Space.Self);

        /*
        Vector3 right = cam.transform.InverseTransformDirection(cam.transform.right * direction.x);
        Vector3 forward = cam.transform.InverseTransformDirection(cam.transform.forward * direction.z);
        Vector3 up = cam.transform.InverseTransformDirection(cam.transform.up * direction.y);

        Vector3 finalDest = transform.localPosition + (right + forward + up);

        //Debug.Log(Vector3.Distance(transform.localPosition + finalDest, cam.transform.localPosition));

        if(Vector3.Distance(transform.localPosition + finalDest, cam.transform.position) >= MinDistanceToCamera)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, finalDest, HandLerpSpeed * Time.fixedDeltaTime);

            //TODO: REWRITE
            transform.localPosition = new Vector3(Mathf.Clamp(transform.localPosition.x, HorizontalOffsetClamp.x, HorizontalOffsetClamp.y),
                Mathf.Clamp(transform.localPosition.y, VerticalOffsetClamp.x, VerticalOffsetClamp.y),
                Mathf.Clamp(transform.localPosition.z, ForwardBackClamp.x, ForwardBackClamp.y)
                );
        }
        */

        Vector3 right = transform.right * direction.x * Sensitivity;
        Vector3 forward = transform.forward * direction.z * Sensitivity;
        Vector3 up = transform.up * direction.y * Sensitivity;

        Vector3 final = right + forward + up;

        transform.position = Vector3.Lerp(transform.position, (transform.position + final), HandLerpSpeed * Time.fixedDeltaTime);

        transform.localPosition = new Vector3(Mathf.Clamp(transform.localPosition.x, HorizontalOffsetClamp.x, HorizontalOffsetClamp.y),
                Mathf.Clamp(transform.localPosition.y, VerticalOffsetClamp.x, VerticalOffsetClamp.y),
                Mathf.Clamp(transform.localPosition.z, ForwardBackClamp.x, ForwardBackClamp.y)
                );
    }
}
