using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform transformToFollow;

    private Vector3 offSet;
    private Vector3 moveTo;
    public float camMoveSpeed = 0f;
    private float tolerenceRange = 1f;
    void Start()
    {
        this.offSet = transformToFollow.position - transform.position;
    }

  
    void LateUpdate()
    {

       


        Vector3 direction = (transformToFollow.position-this.offSet) - transform.position;
        float distanceToNewTarget = direction.magnitude;
        
        if (distanceToNewTarget <= 2f)
        {
            transform.position = transformToFollow.position - this.offSet;

        }
        else
        {
            moveTo = Vector2.Lerp(transform.position, transformToFollow.position, camMoveSpeed * Time.deltaTime);
            transform.position = new Vector3(moveTo.x, moveTo.y, transform.position.z);
        }

        
        
    }

    public void SetNewTarget(Transform newTarget)
    {
        this.transformToFollow = newTarget;

        int var = 3;
        Debug.Log("Shii" + var);
    }
}
