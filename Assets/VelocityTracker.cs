using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityTracker : MonoBehaviour
{
    private Vector3 prevPosition;
    public Vector3 velocity;

    private void Start()
    {
        StartCoroutine(CalcVelocity());
    }

    private IEnumerator CalcVelocity()
    {
        while(true)
        {
            prevPosition = transform.position;
            yield return new WaitForEndOfFrame();
            velocity = (prevPosition - transform.position) / Time.deltaTime;
        }
    }
}
