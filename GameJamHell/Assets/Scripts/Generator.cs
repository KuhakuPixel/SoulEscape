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
    public KeyCode keyToWorkOnGenerator = KeyCode.G;
    PlayerScript playerScript;

    private bool onGeneratorDoneHasBeenCalled = false;
    void OnDrawGizmosSelected()
    {
        
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(detectionPoint.position, detectionRadius);
    }
    private void Start()
    {
        playerScript =FindObjectOfType<PlayerScript>();
    }
    void Update()
    {
        if(DetectObject())
        {
            Debug.Log("Player is nearby generator");
            
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
        return Input.GetKeyDown(keyToWorkOnGenerator);
    }

    bool DetectObject()
    {
        return Physics2D.OverlapCircle(detectionPoint.position,detectionRadius,detectionLayer);
    }
    public void OnGeneratorDone()
    {
        if (!onGeneratorDoneHasBeenCalled)
            onGeneratorDone.Invoke();
        else
            onGeneratorDoneHasBeenCalled = true;

    }
    public bool CanPlayerStartGenerator()
    {
        return playerScript.paperCount >= amountOfPaperToStartGenerator;
    }
}
