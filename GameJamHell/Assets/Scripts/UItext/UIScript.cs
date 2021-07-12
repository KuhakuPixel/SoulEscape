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

    public GameObject iconRed;
    public GameObject iconYellow;
    public GameObject iconPurple;
    public GameObject iconGreen;
    // Start is called before the first frame update
    void Start()
    {
   //     mainMenu.SetActive(true);
     //   gameOver.SetActive(false);
       // hud.SetActive(false);
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

    public void DisableIcon(Puppet.PuppetColors puppetColor) {
        switch(puppetColor) {
            case Puppet.PuppetColors.Red:
             
                iconRed.GetComponent<Image>().color = new Color32(130, 130, 130, 255);
                break;
            
            case Puppet.PuppetColors.Green: 
                iconGreen.GetComponent<Image>().color = new Color32(130, 130, 130, 255);
                break;

            case Puppet.PuppetColors.Purple: 
                iconPurple.GetComponent<Image>().color = new Color32(130, 130, 130, 255);
                break;

            case Puppet.PuppetColors.Yellow: 
                iconYellow.GetComponent<Image>().color = new Color32(130, 130, 130, 255);
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
