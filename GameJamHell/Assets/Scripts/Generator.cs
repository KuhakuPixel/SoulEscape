using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Generator : MonoBehaviour
{
    public Transform detectionPoint;
    public  float detectionRadius = 0.2f;
    public LayerMask detectionLayer;
    public UnityEvent onGeneratorInteraction;
    public UnityEvent onGeneratorRelease;
    public UnityEvent onGeneratorDone;
    public KeyCode keyToWorkOnGenerator;
    void Update()
    {
        if(DetectObject())
        {
            if(InteractiveInput()){
                //GetComponent<SpriteRenderer>().color = Color.yellow;
                onGeneratorInteraction.Invoke();
            }
            if (Input.GetKey(keyToWorkOnGenerator))
            {
                onGeneratorInteraction.Invoke();
            }
            else
            {
                onGeneratorRelease.Invoke();
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
    public void OnGeneratorDone()
    {
        onGeneratorDone.Invoke();
    }
}
