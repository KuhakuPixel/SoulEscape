using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class GameManager : MonoBehaviour
{
    UnityEvent onGameOver;
    UnityEvent onGameStart;
    PlayerScript playerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = FindObjectOfType<PlayerScript>();
        onGameStart.Invoke();
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
}
