using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class FlareDetect : MonoBehaviour
{
    public UnityEvent flareInvokedEvent;
    PlayerScript playerScript;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            flareInvokedEvent.Invoke();
            playerScript = GameObject.FindObjectOfType<PlayerScript>();
            playerScript.flareCount++;
        }
    }
}
