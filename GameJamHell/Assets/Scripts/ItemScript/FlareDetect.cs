using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class FlareDetect : MonoBehaviour
{
    public UnityEvent flareInvokedEvent;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            flareInvokedEvent.Invoke();
            Debug.Log("Player");
        }
    }
}
