using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Pathfinding;
public class GameManager : MonoBehaviour
{
    public UnityEvent onGameOver;
    public UnityEvent onGameStart;
    PlayerScript playerScript;
    public Puppet selectedPuppet;
    public int amountOfPaperToStartGenerator = 0;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = FindObjectOfType<PlayerScript>();
        OnGameStart();
    }

    // Update is called once per frame
    void Update()
    {
        //listening 
        if (playerScript.GetUnsealedPuppetCount() == 0)
        {
            onGameOver.Invoke();
        }
    }
    public void OnGeneratorComplete()
    {

    }
    public void OnGameStart()
    {
        onGameStart.Invoke();
        playerScript.selectedPuppet = selectedPuppet;
        //set all enemy target to current player
        AIDestinationSetter[] enemyTargetSetters =FindObjectsOfType<AIDestinationSetter>();

        foreach( AIDestinationSetter setter in enemyTargetSetters)
        {
            setter.target = selectedPuppet.transform;
        }

        //intialize all generator
        Generator[] generators=FindObjectsOfType<Generator>();

        foreach(Generator generator in generators)
        {
            generator.amountOfPaperToStartGenerator = this.amountOfPaperToStartGenerator;
        }
    }
    public void OnGameOver()
    {
        onGameOver.Invoke();
    }
}
