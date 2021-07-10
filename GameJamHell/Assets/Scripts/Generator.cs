using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public Transform detectionPoint;
    private const float detectionRadius = 0.2f;
    public LayerMask detectionLayer;
    void Update()
    {
        if(DetectObject())
        {
            if(InteractiveInput()){
                GetComponent<SpriteRenderer>().color = Color.yellow;
            }
        }
    }

    bool InteractiveInput()
    {
        return Input.GetKeyDown(KeyCode.G);
    }

    bool DetectObject()
    {
        return Physics2D.OverlapCircle(detectionPoint.position,detectionRadius,detectionLayer);
    }
}
