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
        // for color changing test
        // comment out in production
        if(Input.GetKeyDown(KeyCode.Q)) {
            DisableIcon(Puppet.PuppetColors.Red);
        }

        if(Input.GetKeyDown(KeyCode.W)) {
            DisableIcon(Puppet.PuppetColors.Green);
        }

        if(Input.GetKeyDown(KeyCode.E)) {
            DisableIcon(Puppet.PuppetColors.Purple);
        }

        if(Input.GetKeyDown(KeyCode.R)) {
            DisableIcon(Puppet.PuppetColors.Yellow);
        }

        if(Input.GetKeyDown(KeyCode.Z)) {
            EnableIcon(Puppet.PuppetColors.Red);
        }

        if(Input.GetKeyDown(KeyCode.X)) {
            EnableIcon(Puppet.PuppetColors.Green);
        }

        if(Input.GetKeyDown(KeyCode.C)) {
            EnableIcon(Puppet.PuppetColors.Purple);
        }

        if(Input.GetKeyDown(KeyCode.V)) {
            EnableIcon(Puppet.PuppetColors.Yellow);
        }
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

    public void DisableIcon(Puppet.PuppetColors puppetColor) {
        switch(puppetColor) {
            case Puppet.PuppetColors.Red: 
                GameObject.Find("HUD/IconRed").GetComponent<Image>().color = new Color32(130, 130, 130, 255);
                break;
            
            case Puppet.PuppetColors.Green: 
                GameObject.Find("HUD/IconGreen").GetComponent<Image>().color = new Color32(130, 130, 130, 255);
                break;

            case Puppet.PuppetColors.Purple: 
                GameObject.Find("HUD/IconPurple").GetComponent<Image>().color = new Color32(130, 130, 130, 255);
                break;

            case Puppet.PuppetColors.Yellow: 
                GameObject.Find("HUD/IconYellow").GetComponent<Image>().color = new Color32(130, 130, 130, 255);
                break;
        }     
    }

    public void EnableIcon(Puppet.PuppetColors puppetColor) {
        switch(puppetColor) {
            case Puppet.PuppetColors.Red: 
                GameObject.Find("HUD/IconRed").GetComponent<Image>().color = new Color32(207, 207, 207, 255);
                break;
            
            case Puppet.PuppetColors.Green: 
                GameObject.Find("HUD/IconGreen").GetComponent<Image>().color = new Color32(207, 207, 207, 255);
                break;

            case Puppet.PuppetColors.Purple: 
                GameObject.Find("HUD/IconPurple").GetComponent<Image>().color = new Color32(207, 207, 207, 255);
                break;

            case Puppet.PuppetColors.Yellow: 
                GameObject.Find("HUD/IconYellow").GetComponent<Image>().color = new Color32(207, 207, 207, 255);
                break;
        }     
    }

}
