using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObj : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.01f;  //closer to 0 == slower to catch target
    public Vector3 locationOffset = new Vector3(0, 0, -6.5f);
    // Update is called once per frame
    void FixedUpdate()
    {
        //simple follow
        //transform.position = target.transform.position + new Vector3(0.0f, 0.0f, -6.5f); 

        //smoothed follow
        Vector3 desiredPosition = target.position + locationOffset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

    }
}
