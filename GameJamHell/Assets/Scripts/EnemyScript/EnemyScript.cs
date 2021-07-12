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
    private Animator animator;
    /// <summary>
    /// called when enemy captured the puppet
    /// </summary>
    public UnityEvent onPuppetCaptured;
    private SpriteRenderer enemySprite;
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
        animator = GetComponent<Animator>();
        enemySprite = GetComponent<SpriteRenderer>();
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
                if (!puppet.IsPuppetSealed)
                {
                    puppet.CapturePuppet();
                    onPuppetCaptured.Invoke();
                    //after sealed ,chase the player next
                    enemyDestinationSetter.target = playerScript.selectedPuppet.transform;
                }
           


               

                
            }
        }

        if (enemyDestinationSetter.target!=null)
        {
            Vector3 currentEnemyPosition = enemyDestinationSetter.target.position;
            if (currentEnemyPosition.x<transform.position.x)
            {
                enemySprite.flipX = true;
            }
            else if (currentEnemyPosition.x > transform.position.x)
            {
                enemySprite.flipX = false;
            }
        }
    }

}
