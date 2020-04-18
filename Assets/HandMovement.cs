using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMovement : MonoBehaviour
{
    private float HandLerpSpeed = 1f;

    public Vector2 HorizontalOffsetClamp;
    public Vector2 VerticalOffsetClamp;
    public Vector2 ForwardBackClamp;

    //private Rigidbody rb;
    private bool MoveVertical;

    private Vector3 direction;
    private Vector2 mousePos;

    private ObjectGrabLogic logic;

    // Start is called before the first frame update
    void Awake()
    {
        //rb = GetComponent<Rigidbody>();
        logic = GetComponentInChildren<ObjectGrabLogic>();
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

    // Update is called once per frame
    void FixedUpdate()
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
        Vector3 finalDest = transform.localPosition + direction;

        transform.localPosition = Vector3.Lerp(transform.localPosition, finalDest, HandLerpSpeed * Time.fixedDeltaTime);

        transform.localPosition = new Vector3(Mathf.Clamp(transform.localPosition.x, HorizontalOffsetClamp.x, HorizontalOffsetClamp.y),
            Mathf.Clamp(transform.localPosition.y, VerticalOffsetClamp.x, VerticalOffsetClamp.y),
            Mathf.Clamp(transform.localPosition.z, ForwardBackClamp.x, ForwardBackClamp.y)
            );
        //transform.localPosition = 
    }
}
