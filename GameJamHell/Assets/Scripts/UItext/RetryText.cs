using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class RetryText : MonoBehaviour, IPointerClickHandler
{
    public Text uitext;
    public UnityEvent onClick;
    // Start is called before the first frame update
    void Start(){
        uitext = GetComponent<Text>();
        uitext.text = "RETRY";
        uitext.enabled = false;
    }
    public void OnPointerClick(PointerEventData pointerEventData){
        Debug.Log("clicked retry");
        onClick.Invoke();
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
