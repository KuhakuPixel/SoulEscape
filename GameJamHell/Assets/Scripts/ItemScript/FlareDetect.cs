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
            playerScript = collision.gameObject.GetComponent<PlayerScript>();


            if (playerScript == null)
            {
                Debug.Log("Null");
            }
            else
            {
                Debug.Log("no null");
            }
            
        }
    }
}
