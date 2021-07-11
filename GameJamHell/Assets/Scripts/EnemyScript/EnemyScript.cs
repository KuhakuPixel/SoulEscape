using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class EnemyScript : MonoBehaviour
{
    AIDestinationSetter enemyDestinationSetter;
    PlayerScript playerScript;
    // Start is called before the first frame update
    void Start()
    {
         playerScript = GameObject.FindObjectOfType<PlayerScript>();
        this.enemyDestinationSetter = this.GetComponent<AIDestinationSetter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScript.selectedPuppet.transform != enemyDestinationSetter.target.transform)
        {
            enemyDestinationSetter.target = playerScript.selectedPuppet.transform;
        }
       
    }
}
