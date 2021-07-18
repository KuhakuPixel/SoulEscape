using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// used for flare and paper since behaviour is similiar
/// </summary>
public class PickableItemScript : MonoBehaviour
{
    public UnityEvent onItemPickedUp;
    PlayerScript playerScript;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            onItemPickedUp.Invoke();
            //playerScript = GameObject.FindObjectOfType<PlayerScript>();
            //playerScript.flareCount++;
        }
    }
}
