using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Experimental.Rendering.Universal;
public class PlayerScript : MonoBehaviour
{
    public float flareTimeExpires;
    public UIScript uiScript;
    public KeyCode keyToUnsealPuppet = KeyCode.E;
    public KeyCode keyToPutFlare = KeyCode.F;
    public UnityEvent onPlayerMove;
    public UnityEvent onPlayerWin;
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
    [HideInInspector]public Puppet selectedPuppet;
    public int flareCount = 0;
    public UnityEvent onPlayerPickedUpFlare;
    public UnityEvent onPlayerPutFlare;
     public int paperCount = 0;
    public UnityEvent onPlayerPickedUpPaper;

    public Transform lightTransform;

    // public GameObject flarePrefab;
    public SpawnerManager spawnerManager;
    bool canPutFlare = true;
    float time;

    public AudioManager audioManager;
    // Start is called before the first frame update
    private void Awake()
    {
        if (puppets.Count != 4)
        {
            throw new System.ArgumentException("Puppet must be 4");
        }
        spawnerManager = FindObjectOfType<SpawnerManager>();
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
        // select doll based on input
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

        // movement
        Vector2 inputVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (inputVector.magnitude > 1)
        {
            inputVector.Normalize();
        }
        selectedPuppet.MovePuppet(inputVector, playerSpeed);

        lightTransform.position = selectedPuppet.transform.position;

        if(inputVector != Vector2.zero) {
            // TODO : play footstep sfx
            onPlayerMove.Invoke();
        }

        // put flare logic
        if(Input.GetKeyDown(keyToPutFlare) && canPutFlare && flareCount > 0) {
            // canPutFlare = false;
            // flareCount--;
            time = Time.time;
            PutFlare();

            // GameObject flare = GameObject.Instantiate(flarePrefab, selectedPuppet.transform.position, Quaternion.identity);
            // flare.transform.position = selectedPuppet.transform.position;
            // flare.name = "Flare from player";
            // flare.SetActive(true);
            // spawn flare at current position
            // add light
        }

    }
    Puppet.PuppetColors PuppetIndexToEnum(int index)
    {
        Puppet.PuppetColors color=Puppet.PuppetColors.Green;
        if (index == 0)
        {
            color = Puppet.PuppetColors.Red;
        }
        else if (index == 1)
        {
            color = Puppet.PuppetColors.Yellow;
        }
        else if (index == 2)
        {
            color = Puppet.PuppetColors.Green;
        }
        else if (index == 3)
        {
            color = Puppet.PuppetColors.Purple;
        }
        return color;
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

              
                uiScript.DisableIcon(PuppetIndexToEnum(i));
               
          
             
            }
            puppets[selectedPuppetIndex].SelectPuppet();
            uiScript.EnableIcon(PuppetIndexToEnum(selectedPuppetIndex));
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

        //moved to event onGameOver
        //uiScript.ShowGameOver();

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

    public void PickUpFlare()
    {
        flareCount++;
        onPlayerPickedUpFlare.Invoke();
    }

    public void PutFlare() {
        audioManager.Play("flare_on");
        flareCount--;
        GameObject spawnedFlare=spawnerManager.SpawnFlare(selectedPuppet.transform.position);
        spawnedFlare.GetComponent<Light2D>().enabled=true;
        spawnedFlare.GetComponent<PickableItemScript>().IsItemPickable = false;
        EnemyScript[] enemies=FindObjectsOfType<EnemyScript>();
        //fool the enemy pls
        for(int i = 0; i < enemies.Length; i++)
        {
            enemies[i].SetChase(spawnedFlare.transform);
        }
        Destroy(spawnedFlare, flareTimeExpires);
        onPlayerPutFlare.Invoke();
        
    }

    public void PickUpPaper()
    {
        paperCount++;
        onPlayerPickedUpPaper.Invoke();
    }
}
