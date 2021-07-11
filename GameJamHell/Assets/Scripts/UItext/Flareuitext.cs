using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flareuitext : MonoBehaviour
{
    private int flareCount = 0;
    public Text uitext;
    // Start is called before the first frame update
    void Start()
    {
        //playerScript = GameObject.FindObjectOfType<PlayerScript>();
        uitext.GetComponent<Text>().text = flareCount + "/4";

    }
    void Update()
    {
        if(InteractiveInput()){
            flareCount++;
            uitext.GetComponent<Text>().text = flareCount + "/4";
        }
    }
    bool InteractiveInput()
    {
        return Input.GetKeyDown(KeyCode.G);
    }


}
