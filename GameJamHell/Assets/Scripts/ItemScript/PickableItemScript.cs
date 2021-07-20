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
    public UnityEvent<string> onItemPickedUp;
    private bool isItemPickable = false;
    PlayerScript playerScript;

    public bool IsItemPickable {set => isItemPickable = value; }

    public void Start() {
        playerScript = GameObject.FindObjectOfType<PlayerScript>();

        onItemPickedUp.AddListener(ItemPickUp);
    }
   
    public void InitializeItemProperty(PickableItemSpawnProperty itemProperty)
    {
        if (itemProperty != null)
        {
            this.itemProperty = itemProperty;
        }
        else
        {
            Debug.LogError("itemProperty is null");
        }
      
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
            if (isItemPickable)
            {
                onItemPickedUp.Invoke(this.tag);
                DestroyObjectFromScene();

            }

        }
    }

    void ItemPickUp(string tag) {
        

        if(tag == "Flare") {
            playerScript.PickUpFlare();
        }
        else if(tag == "Paper") {
            playerScript.PickUpPaper();
        }
    }

}
