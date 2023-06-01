using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Vector3 offset;
    public Transform TargetToFollow;
    void Update()
    {
        transform.position = TargetToFollow.position + offset;
        transform.LookAt(TargetToFollow);
    }
}
