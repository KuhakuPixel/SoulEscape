using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float playerSpeed = 0f;
    public List<Puppet> puppets = new List<Puppet>();
    public Puppet selectedPuppet;
    public int flareCount = 0;
    // Start is called before the first frame update
    private void Awake()
    {
        if (puppets.Count != 4)
        {
            throw new System.ArgumentException("Puppet must be 4");
        }
    }
    void Start()
    {
        //init new doll
        for(int i = 0; i < puppets.Count; i++)
        {
            if (selectedPuppet == puppets[i])
            {
                SelectNewDoll(i);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectNewDoll(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectNewDoll(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SelectNewDoll(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SelectNewDoll(3);
        }
        Vector2 inputVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (inputVector.magnitude > 1)
        {
            inputVector.Normalize();
        }
        selectedPuppet.MovePuppet(inputVector, playerSpeed);
 

    }

    public void SelectNewDoll(int index)
    {
        //disable other doll and enable new one
        selectedPuppet = puppets[index];
        for(int i = 0; i < puppets.Count; i++)
        {
            if (selectedPuppet != puppets[i])
            {
                puppets[i].DisablePuppet();
            }
            else
            {
                puppets[i].EnablePuppet();
            }
        }
        GameObject.FindObjectOfType<CameraMovement>().SetNewTarget(selectedPuppet.transform);
        
    }
}
