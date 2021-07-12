using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerScript : MonoBehaviour
{
    public KeyCode keyToUnsealPuppet = KeyCode.E;
    /// <summary>
    /// Invoked when select a sealed puppet
    /// </summary>
    public UnityEvent onSelectingSealedPuppet;

    /// <summary>
    /// Invoked when selecting an available  puppet
    /// </summary>
    public UnityEvent onSelectingUnSealedPuppet;
    public float playerSpeed = 0f;
    public List<Puppet> puppets = new List<Puppet>();
    public Puppet selectedPuppet;
    public int flareCount = 0;

    public Transform lightTransform;
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
        for (int i = 0; i < puppets.Count; i++)
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
        Vector2 inputVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (inputVector.magnitude > 1)
        {
            inputVector.Normalize();
        }
        selectedPuppet.MovePuppet(inputVector, playerSpeed);

        lightTransform.position = selectedPuppet.transform.position;

    }

    public void SelectNewDoll(int selectedPuppetIndex)
    {
        //change only if puppet is sealed
        if (!puppets[selectedPuppetIndex].IsPuppetSealed)
        {
            onSelectingUnSealedPuppet.Invoke();
            for (int i = 0; i < puppets.Count; i++)
            {
                puppets[i].UnSelectPuppet();
            }
            puppets[selectedPuppetIndex].SelectPuppet();
            selectedPuppet = puppets[selectedPuppetIndex];
        }
        else
        {
            Debug.Log("Puppet is sealed , Cannot teleport Nub");
            onSelectingSealedPuppet.Invoke();
        }

        GameObject.FindObjectOfType<CameraMovement>().SetNewTarget(selectedPuppet.transform);

    }
    public void ForcePlayerToMoveToAnotherPuppet()
    {
        for(int i = 0; i < puppets.Count; i++)
        {
            if (!puppets[i].IsPuppetSelected && !puppets[i].IsPuppetSealed)
            {
                SelectNewDoll(i);
                return;
            }
        }

        Debug.Log("no unsealed puppet remaining ");
        //if no puppet left then game over
    }

    public int GetUnsealedPuppetCount()
    {
        int count = 0;
        for(int i = 0; i < puppets.Count; i++)
        {
            if (!puppets[i].IsPuppetSealed)
            {
                count++; 
            }
        }
        return count;
    }
}
