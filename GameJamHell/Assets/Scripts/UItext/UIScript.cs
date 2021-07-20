using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    public GameManager gameManager;
    public PlayerScript playerScript;
    public GameObject mainMenu;
    public GameObject gameOver;
    public GameObject hud;
    public GameObject victory;

    public Text flareText;
    public Text paperText;

    public GameObject iconRed;
    public GameObject iconYellow;
    public GameObject iconPurple;
    public GameObject iconGreen;
    // Start is called before the first frame update
    void Start()
    {
       mainMenu.SetActive(true);
       gameOver.SetActive(false);
       hud.SetActive(false);
       victory.SetActive(false);

       Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartClick() {
        gameManager.isGameStarting = true;
        Time.timeScale = 1;
        mainMenu.SetActive(false);
        hud.SetActive(true);
    }

    public void RetryClick() {
        // TODO : reload scene skipping main menu screen
        gameOver.SetActive(false);
        hud.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitClick() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // mainMenu.SetActive(true);
        // gameOver.SetActive(false);
    }

    public void ShowGameOver() {
        gameManager.isGameStarting = false;
        Time.timeScale = 0;
        hud.SetActive(false);
        gameOver.SetActive(true);
    }

    public void ShowVictoryPanel() {
        gameManager.isGameStarting = false;
        Time.timeScale = 0;
        hud.SetActive(false);
        victory.SetActive(true);
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
                iconRed.GetComponent<Image>().color = new Color32(207, 207, 207, 255);
                break;
            
            case Puppet.PuppetColors.Green: 
                iconGreen.GetComponent<Image>().color = new Color32(207, 207, 207, 255);
                break;

            case Puppet.PuppetColors.Purple: 
                iconPurple.GetComponent<Image>().color = new Color32(207, 207, 207, 255);
                break;

            case Puppet.PuppetColors.Yellow: 
                iconYellow.GetComponent<Image>().color = new Color32(207, 207, 207, 255);
                break;
        }     
    }

    public void UpdateFlareCount() {
        flareText.text = playerScript.flareCount.ToString();
    }

    public void UpdatePaperCount() {
        paperText.text = playerScript.paperCount.ToString();
    }

}
