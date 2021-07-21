using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Generator : MonoBehaviour
{
    public AudioManager audioManager;
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
   

    private bool onGeneratorDoneHasBeenCalled = false;
    void OnDrawGizmosSelected()
    {
        
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(detectionPoint.position, detectionRadius);
    }
    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        playerScript =FindObjectOfType<PlayerScript>();

        onGeneratorStart.AddListener(PlayGeneratorSound);
        onGeneratorRelease.AddListener(StopGeneratorSound);
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
                    // audioManager.Play("generator_running");
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
                // audioManager.Stop("generator_running");

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
            audioManager.Play("door_open");
            onGeneratorDone.Invoke();
        }
      

    }
    
    public bool CanPlayerStartGenerator()
    {
        return playerScript.paperCount >= amountOfPaperToStartGenerator;
    }

    void PlayGeneratorSound() {
        audioManager.Play("generator_running");
    }

    void StopGeneratorSound() {
        audioManager.Stop("generator_running");
    }
}
