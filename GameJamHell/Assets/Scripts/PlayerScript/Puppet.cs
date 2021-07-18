using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Puppet : MonoBehaviour
{
    public float puppetInteractionRadius = 5f;

    private bool isPuppetSelected = false;
    private bool isPuppetSealed = false;
    private Vector2 moveDir;



    private PlayerScript playerScript;
    private Rigidbody2D playerRB;
    private Animator puppetAnimator;
    private SpriteRenderer puppetSprite;

    public bool IsPuppetSealed { get => isPuppetSealed; }
    public bool IsPuppetSelected { get => isPuppetSelected; }

    public enum PuppetColors {
        Red,
        Green,
        Purple,
        Yellow
    }

    public PuppetColors puppetColor;

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
        if (isPuppetSelected)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, puppetInteractionRadius);

            foreach (Collider2D collider in colliders)
            {
                if (collider.tag == "Player")
                {
                    if(Input.GetKeyDown(playerScript.keyToUnsealPuppet)) {
                        Puppet puppet = collider.gameObject.GetComponent<Puppet>();
                        if (puppet.IsPuppetSealed)
                        {
                            puppet.UnSealPuppet();
                            Debug.Log("unseal puppet");
                        }

                    }
                }
                else if(collider.tag == "Flare") {
                    // respawn flare
                    collider.gameObject.SetActive(false);
                    playerScript.PickUpFlare();
                }
                else if (collider.tag == "Paper") {
                    collider.gameObject.SetActive(false);
                    playerScript.PickUpPaper();
                }
                else if(collider.tag == "Door") {
                    Debug.Log("Win");
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


    

    public void CapturePuppet()
    {
        this.SealPuppet();
        Debug.Log("Puppet captured");
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
        Color oldPuppetColor = this.GetComponent<SpriteRenderer>().color;
        this.GetComponent<SpriteRenderer>().color = new Color(oldPuppetColor.r, oldPuppetColor.g, oldPuppetColor.b, 0.3f);

        if (playerScript.selectedPuppet.gameObject.name == this.gameObject.name)
        {
            playerScript.ForcePlayerToMoveToAnotherPuppet();
        }
    }
    public void UnSealPuppet()
    {
        this.isPuppetSealed = false;
        Color color = GetComponent<SpriteRenderer>().color;
        GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, 1f);
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
