using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// used for flare and paper since behaviour is similiar
/// </summary>
public class PickableItemScript : MonoBehaviour
{
    private PickableItemSpawnProperty itemProperty;
    public UnityEvent onItemPickedUp;
    PlayerScript playerScript;
    public void InitializeItemProperty(PickableItemSpawnProperty itemProperty)
    {
        this.itemProperty = itemProperty;
    }
    public void DestroyObjectFromScene()
    {
        for(int i = 0; i < itemProperty.spawnedItems.Count; i++)
        {
            if (this.gameObject == itemProperty.spawnedItems[i])
            {
                Debug.Log("Destroyed :" +this.gameObject.name);
                itemProperty.spawnedItems.RemoveAt(i);
                Destroy(this.gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            onItemPickedUp.Invoke();
            DestroyObjectFromScene();
      
        }
    }
}
