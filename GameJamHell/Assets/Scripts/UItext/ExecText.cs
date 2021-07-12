using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class ExecText : MonoBehaviour,  IPointerClickHandler
{
     public Text uitext;
     public Text startTitle;
    public UnityEvent onClick;
    // Start is called before the first frame update
    void Start(){
        uitext = GetComponent<Text>();
        startTitle = GetComponent<Text>();
        uitext.enabled = true;
        startTitle.enabled = true;
    }
    public void OnPointerClick(PointerEventData pointerEventData){
        Debug.Log("clicked start");
        onClick.Invoke();
        uitext.enabled = false;
        startTitle.enabled = false;
        
    }
   
}