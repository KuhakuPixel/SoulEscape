using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.Events;
public class EnemyScript : MonoBehaviour
{
    public float captureRadius=0f;
    AIDestinationSetter enemyDestinationSetter;
    PlayerScript playerScript;
    private Puppet lastChasedPuppet;
    private Puppet currentlyChasingPuppet;
    /// <summary>
    /// called when enemy captured the puppet
    /// </summary>
    public UnityEvent onPuppetCaptured;

    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,captureRadius);
    }
    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.FindObjectOfType<PlayerScript>();
        this.enemyDestinationSetter = this.GetComponent<AIDestinationSetter>();

    }

    // Update is called once per frame
    void Update()
    {
        //logic:seal first the firstly chased target before chasing the another one
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, captureRadius);
        foreach (Collider2D collider in colliders)
        {
            //capture player
            if (collider.tag == "Player")
            {
                Puppet puppet=collider.gameObject.GetComponent<Puppet>();
                puppet.CapturePuppet();
                onPuppetCaptured.Invoke();
                //after sealed ,chase the player next
                enemyDestinationSetter.target = playerScript.selectedPuppet.transform;


               

                
            }
        }
    }

}
