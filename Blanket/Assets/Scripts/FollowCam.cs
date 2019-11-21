using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]


public class FollowCam : MonoBehaviour
{

    public Transform followTarget;
    public float speed;


    void FixedUpdate()
    {
        if (followTarget == null) return;

        Vector3 targetPos = followTarget.position;
        targetPos.z = this.transform.position.z;

        Vector3 velocity = (targetPos - transform.position) * speed;

        this.transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, 1.0f, Time.fixedDeltaTime);
    }
}
