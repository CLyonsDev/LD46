using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowHandMotion : MonoBehaviour
{
    public Transform Hand;

    public float horizSpeed = 1.5f;
    public float vertSpeed = 1f;

    public Vector2 HorizontalClamp;
    public Vector2 VerticalClamp;

    public float DistanceFromCenter;
    Vector2 ScreenOrigin;

    private void Awake()
    {
        ScreenOrigin.x = Screen.width / 2;
        ScreenOrigin.y = Screen.height / 2;
    }

    void Update()
    {
        Vector3 handPoint = Camera.main.WorldToScreenPoint(Hand.position);
        handPoint.z = this.transform.position.z;

        Vector2 dst = new Vector2(ScreenOrigin.x - handPoint.x, ScreenOrigin.y - handPoint.y);

        DistanceFromCenter = Mathf.Abs(dst.magnitude);

        if(DistanceFromCenter >= 125f)
        {
            //TODO: Vertical looking should be slower than horizontal.

            Quaternion targetRot = Quaternion.LookRotation(Hand.position - transform.position);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, horizSpeed * Time.deltaTime);
        }
    }
}
