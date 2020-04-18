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

    void FixedUpdate()
    {
        float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");

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
    }
}
