using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Generator : MonoBehaviour
{
    public Transform detectionPoint;
    [HideInInspector]public int amountOfPaperToStartGenerator = 0;
    public  float detectionRadius = 0.2f;
    public LayerMask detectionLayer;
    public UnityEvent onGeneratorStart;
    public UnityEvent onGeneratorStartFail;
    public UnityEvent onGeneratorRelease;
    public UnityEvent onGeneratorDone;
    public KeyCode keyToWorkOnGenerator = KeyCode.G;
    PlayerScript playerScript;
    public GameObject progressBar;

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
            //Debug.Log("Player is nearby generator");
            
            if (Input.GetKey(keyToWorkOnGenerator))
            {
                if (CanPlayerStartGenerator() && !onGeneratorDoneHasBeenCalled)
                {
                    onGeneratorStart.Invoke();
                }
                else
                {
                    onGeneratorStartFail.Invoke();
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
        if (!onGeneratorDoneHasBeenCalled){
            onGeneratorDoneHasBeenCalled = true;
            progressBar.SetActive(false);
            onGeneratorDone.Invoke();
        }
        else{}

    }
    
    public bool CanPlayerStartGenerator()
    {
        return playerScript.paperCount >= amountOfPaperToStartGenerator;
    }
}
