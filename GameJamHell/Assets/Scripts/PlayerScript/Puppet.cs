using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puppet : MonoBehaviour
{
    private bool isPuppetSelected=false;
    private Rigidbody2D playerRB;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = this.GetComponent<Rigidbody2D>();
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
          //  transform.Translate(moveDir * speed * Time.deltaTime, Space.World);
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
