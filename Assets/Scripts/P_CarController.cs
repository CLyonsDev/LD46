using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool Motor;      // Is this wheel attached to the motor?
    public bool Steering;   // Does this wheel apply to the steer angle?
}

public class P_CarController : MonoBehaviour
{

    public List<AxleInfo> axleList; // Information about each axle
    public float maxMotorTorque;
    public float maxSteeringAngle;
    public float brakeTorque;

    private bool isBraking = false;

    private float motor;
    private float steering;

    void FixedUpdate()
    {
        if(!isBraking)
        {
            motor = maxMotorTorque * Input.GetAxis("Vertical");
        }
        else
        {
            motor = 0;
        }

        steering = maxSteeringAngle * Input.GetAxis("Horizontal");

        foreach (AxleInfo axle in axleList)
        {
            if(axle.Steering == true)
            {
                axle.leftWheel.steerAngle = steering;
                axle.rightWheel.steerAngle = steering;
            }
            if(axle.Motor == true)
            {
                axle.leftWheel.motorTorque = motor;
                axle.rightWheel.motorTorque = motor;
            }
        }

        if(Input.GetKey(KeyCode.LeftShift))
        {
            foreach (AxleInfo axle in axleList)
            {
                if (axle.Motor == true)
                {
                    axle.leftWheel.brakeTorque = brakeTorque;
                    axle.rightWheel.brakeTorque = brakeTorque;
                }
            }
        }
        else
        {
            foreach (AxleInfo axle in axleList)
            {
                if (axle.Motor == true)
                {
                    axle.leftWheel.brakeTorque = 0;
                    axle.rightWheel.brakeTorque = 0;
                }
            }
        }
    }
}
