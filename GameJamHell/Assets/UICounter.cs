using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UICounter : MonoBehaviour
{
    Text textCounter;
    int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        this.textCounter = gameObject.GetComponent<Text>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void IncrementCounter()
    {
        counter++;
        textCounter.text = counter.ToString();
    }
    public void DecrementCounter()
    {
        counter--;
        textCounter.text = counter.ToString();
    }


}
