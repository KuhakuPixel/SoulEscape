using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlareDetect : MonoBehaviour
{
    public Transform detectionPoint;
    private const float detectionRadius = 0.2f;
    public LayerMask detectionLayer;
    void Update()
    {
        if(DetectObject())
        {
            gameObject.SetActive(false);
        }
    }

    bool InteractiveInput()
    {
        return Input.GetKeyDown(KeyCode.E);
    }

    bool DetectObject()
    {
        return Physics2D.OverlapCircle(detectionPoint.position,detectionRadius,detectionLayer);
    }
}
