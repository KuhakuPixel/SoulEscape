using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Puppet : MonoBehaviour
{
    public float puppetInteractionRadius = 0f;

    private bool isPuppetSelected = false;
    public bool isPuppetSealed = false;
    private Vector2 moveDir;



    private PlayerScript playerScript;
    private Rigidbody2D playerRB;
    private Animator puppetAnimator;
    private SpriteRenderer puppetSprite;

    public bool IsPuppetSealed { get => isPuppetSealed; }
    public bool IsPuppetSelected { get => isPuppetSelected; }

    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, puppetInteractionRadius);
    }
    // Start is called before the first frame update
    void Start()
    {
        playerRB = this.GetComponent<Rigidbody2D>();
        puppetAnimator = this.GetComponent<Animator>();
        puppetSprite = this.GetComponent<SpriteRenderer>();
        playerScript = GameObject.FindObjectOfType<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //try to unseal another puppet
        if (isPuppetSelected && Input.GetKeyDown(playerScript.keyToUnsealPuppet))
        {

            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, puppetInteractionRadius);
            foreach (Collider2D collider in colliders)
            {
                if (collider.tag == "Player")
                {
                    Puppet puppet = collider.gameObject.GetComponent<Puppet>();
                    if (puppet.IsPuppetSealed)
                    {
                        puppet.UnSealPuppet();
                    }
                }
            }
        }

        if (!isPuppetSelected) {
            playerRB.velocity = new Vector2(0, 0);
            puppetAnimator.SetBool("isWalking", false);
        }
    }

    public void MovePuppet(Vector2 moveDirection, float speed)
    {
        if (this.isPuppetSelected)
        {
            moveDir = moveDirection;
            if (moveDir.x != 0 || moveDir.y != 0)
            {
                puppetAnimator.SetBool("isWalking", true);
            }
            else
            {
                puppetAnimator.SetBool("isWalking", false);
            }

            if (moveDir.x > 0)
            {
                puppetSprite.flipX = true;
            }
            else if (moveDir.x < 0)
            {
                puppetSprite.flipX = false;
            }

            playerRB.velocity = moveDir * speed * Time.deltaTime;
        }

    }


    public bool IsSelectedPuppetInThisRadius()
    {
        Vector3 selectedPuppetPosition = playerScript.selectedPuppet.transform.position;

        float distanceBetweenSelectedPuppet = Vector3.Distance(transform.position, selectedPuppetPosition);
        if (distanceBetweenSelectedPuppet <= puppetInteractionRadius)
        {
            return true;
        }
        else
        {
            return false;
        }



       
    }

    public void CapturePuppet()
    {
        this.SealPuppet();
        playerScript.ForcePlayerToMoveToAnotherPuppet();
        Color oldPuppetColor = this.GetComponent<SpriteRenderer>().color;
        this.GetComponent<SpriteRenderer>().color = new Color(oldPuppetColor.r, oldPuppetColor.g, oldPuppetColor.b, 50f);
    }
    /// <summary>
    /// Player can unseal another puppet
    /// </summary>
    public void UnsealAnotherPuppet(Puppet puppet)
    {
        puppet.UnSealPuppet();
    }
    public void SealPuppet()
    {
        this.isPuppetSealed = true;
    }
    public void UnSealPuppet()
    {
        this.isPuppetSealed = false;
    }
    public void UnSelectPuppet()
    {
        this.isPuppetSelected = false;
    }
    public void SelectPuppet()
    {



        this.isPuppetSelected = true;


    }
}
