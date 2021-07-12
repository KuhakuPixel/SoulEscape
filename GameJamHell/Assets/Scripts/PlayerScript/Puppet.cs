using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Puppet : MonoBehaviour
{
    private bool isPuppetSelected=false;
    private Rigidbody2D playerRB;
    private Animator puppetAnimator;
    private SpriteRenderer puppetSprite;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = this.GetComponent<Rigidbody2D>();
        puppetAnimator = this.GetComponent<Animator>();
        puppetSprite = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MovePuppet(Vector2 moveDirection,float speed)
    {
        if (this.isPuppetSelected)
        {
            Vector3 moveDir = moveDirection;
            if (moveDir.x!= 0||moveDir.y!=0)
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
            else if(moveDir.x<0)
            {
                puppetSprite.flipX = false;
            }

            playerRB.velocity = moveDir * speed * Time.deltaTime;
        }
        
    }
    public void DisablePuppet()
    {
        this.isPuppetSelected = false;
    }
    public void EnablePuppet()
    {
        this.isPuppetSelected = true;
    }
}
