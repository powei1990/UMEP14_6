using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUP : Interactable
{
    public Item item;


    public override void Interact()
    {
        PickUp();
        // Debug.Log(Interacted);
    }

    private void PickUp()
    {
        //if (other.gameObject.CompareTag("Item"))
        //{
        bool wasPickedUp = Inventory.instance.Add(item);    // Add to inventory

        // If successfully picked up
        if (wasPickedUp)
            Destroy(gameObject);
        Debug.Log("Picking up " + item.ItemName);
        //}
    }

    public void Buy()
    {
        if (Inventory.instance.Money >= item.Cost)
        {
            Inventory.instance.Add(item);
            Inventory.instance.Money -=item.Cost;
            Debug.Log("Buy"+item.ItemName+"Remaining"+Inventory.instance.Money);
            AudioManager.instance.Play("Sell&BuyItem");
        }
        else
        {
            Debug.Log("You don't have money!");
        }
    }


}
