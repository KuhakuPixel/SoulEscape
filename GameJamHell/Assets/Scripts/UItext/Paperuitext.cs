using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Paperuitext : MonoBehaviour
{
    private int paperCount = 0;
    public Text uitext;
    // Start is called before the first frame update
    void Start()
    {
        //playerScript = GameObject.FindObjectOfType<PlayerScript>();
        uitext.GetComponent<Text>().text = "Paper : "+ paperCount + "/4";

    }
    void Update()
    {
        if(InteractiveInput()){
            paperCount++;
            uitext.GetComponent<Text>().text = "Paper : "+ paperCount + "/4";
        }
    }
    bool InteractiveInput()
    {
        return Input.GetKeyDown(KeyCode.E);
    }
}
