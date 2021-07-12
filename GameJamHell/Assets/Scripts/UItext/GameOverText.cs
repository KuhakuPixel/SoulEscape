using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverText : MonoBehaviour
{
    public Text uitext;
    // Start is called before the first frame update
    void Start(){
        uitext = GetComponent<Text>();
        uitext.text = "GAME OVER";
        uitext.enabled = false;
    }
    void Update()
    {
        if(InteractiveInput()){
            uitext.enabled = true;
        }
    }
    bool InteractiveInput()
    {
        return Input.GetKeyDown(KeyCode.E);
    }
}
