using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puppet : MonoBehaviour
{
    private bool isPuppetSelected=false;
    // Start is called before the first frame update
    void Start()
    {
        
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
            transform.Translate(moveDir * speed * Time.deltaTime, Space.World);
            Debug.Log("move puppet");
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
