using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform transformToFollow;
    private Vector3 offSet;
 
    void Start()
    {
        this.offSet = transformToFollow.position - transform.position;
    }

  
    void LateUpdate()
    {
        transform.position = transformToFollow.position - this.offSet;
    }
}
