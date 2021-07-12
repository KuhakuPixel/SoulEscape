using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Generator : MonoBehaviour
{
    public Transform detectionPoint;
    public int amountOfPaperToStartGenerator = 0;
    public  float detectionRadius = 0.2f;
    public LayerMask detectionLayer;
    public UnityEvent onGeneratorInteraction;
    public UnityEvent onGeneratorRelease;
    public UnityEvent onGeneratorDone;
    public KeyCode keyToWorkOnGenerator;
    PlayerScript playerScript;
    private void Start()
    {
        playerScript = GetComponent<PlayerScript>();
    }
    void Update()
    {
        if(DetectObject())
        {
            if(InteractiveInput()){
             
                onGeneratorInteraction.Invoke();
            }
            if (Input.GetKey(keyToWorkOnGenerator))
            {
                if (CanPlayerStartGenerator())
                {
                    onGeneratorInteraction.Invoke();
                }
                else
                {
                    Debug.Log("Not enough paper");
                }
               
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
    public bool CanPlayerStartGenerator()
    {
        return playerScript.paperCount >= amountOfPaperToStartGenerator;
    }
}
