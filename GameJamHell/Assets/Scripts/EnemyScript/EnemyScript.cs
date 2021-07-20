using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.Events;
public class EnemyScript : MonoBehaviour
{
    public GameManager gameManager;
    public float timeDelay = 0f;
    public float captureRadius=0f;
    AIDestinationSetter enemyDestinationSetter;
    PlayerScript playerScript;
    private Animator animator;
    /// <summary>
    /// called when enemy captured the puppet
    /// </summary>
    public UnityEvent onMonsterWalking;
    public UnityEvent onPuppetCaptured;
    public UnityEvent onTurningOffFlare;
    private SpriteRenderer enemySprite;

    public AudioManager audioManager;
    bool isOnDelay = false;
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
    IEnumerator SetChaseCoroutine(Transform target, float timeDelay)
    {
        isOnDelay = true;
        yield return new WaitForSeconds(timeDelay);
        isOnDelay = false;
        this.enemyDestinationSetter.target = target;

    }

    public void SetChase(Transform target)
    {
        StartCoroutine(SetChaseCoroutine(target,timeDelay));
    }
    GameObject GetCurrentlyChasedGameObject()
    {
        return this.enemyDestinationSetter.target.gameObject;
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
                    SetChase(playerScript.selectedPuppet.transform);
                }
 
               

                
            }
            //fooled lol
            else if (collider.tag == "Flare"  && GetCurrentlyChasedGameObject().tag=="Flare")
            {
                audioManager.Play("flare_off");
                Debug.Log("Rechase Player");
                SetChase(playerScript.selectedPuppet.transform);
                Destroy(collider.gameObject);
                onTurningOffFlare.Invoke();
            }
        }

        if (enemyDestinationSetter.target!=null)
        {
            if(gameManager.isGameStarting && !isOnDelay) {
                onMonsterWalking.Invoke();
            }
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
        else
        {
            SetChase(playerScript.selectedPuppet.transform);
        }
    }
   
}
