using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class ProgressBarScript : MonoBehaviour
{
    private bool startFilling=false;
    private float timeToMakeBarFull;
    private Slider slider;
    public UnityEvent onBarProgressFinished;
    private bool barIsFinished=false;
    // Start is called before the first frame update
    void Start()
    {
        slider=gameObject.GetComponent<Slider>();
        slider.minValue = 0f;
        slider.maxValue = 1f;
    }

    // Update is called once per frame
    void Update()
    {
       // //if (Input.GetKeyDown(KeyCode.G))
        //{
       //     StartFillingProgressBar(15f);
      //  }
       
        if (startFilling)
        {
            slider.value += (1 / timeToMakeBarFull) * Time.deltaTime;
        }
        if (!barIsFinished&&slider.value==slider.maxValue)
        {
            onBarProgressFinished.Invoke();
            barIsFinished = true;

        }
    }

    public void StartFillingProgressBar(float timeToMakeBarFull)
    {
        this.startFilling = true;
        this.timeToMakeBarFull = timeToMakeBarFull;
    }
    public void EndFillingProgressBar()
    {
        this.startFilling = false;
    }
    public void OnProgressBarFull()
    {
        onBarProgressFinished.Invoke();
    }
}
