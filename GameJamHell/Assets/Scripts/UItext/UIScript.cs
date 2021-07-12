using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UIScript : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject gameOver;
    public GameObject hud;

    // Start is called before the first frame update
    void Start()
    {
        mainMenu.SetActive(true);
        gameOver.SetActive(false);
        hud.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartClick() {
        mainMenu.SetActive(false);
        hud.SetActive(true);
    }

    public void RetryClick() {
        gameOver.SetActive(false);
        hud.SetActive(true);
    }

    public void QuitClick() {
        mainMenu.SetActive(true);
        gameOver.SetActive(false);
    }

}
