using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rumble : MonoBehaviour
{
    public float Speed;
    public float Magnitude;

    void Update()
    {
        Vector3 Dest = new Vector3(transform.position.x, Random.Range(-Magnitude, Magnitude), transform.position.z);

        transform.localPosition = Vector3.Slerp(transform.position, Dest, Speed * Time.deltaTime);
    }
}
