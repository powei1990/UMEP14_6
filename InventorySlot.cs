using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public Image icon;
    public Button removeButton;
    public Text DescriptionText;
    public Text ItemNameText;
    //public Text ItemAmount;
    public GameObject ItemInformation;

    Item item;

    public void ShowItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
        DescriptionText.text = newItem.Description;
        ItemNameText.text = newItem.ItemName;
        //Debug.Log("Add Item in Inventory");
        //ItemAmount.text =""+newItem.Amount;
        //if (newItem.Amount > 1)
        //{
        //    ItemAmount.enabled = true;
        //}
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
        DescriptionText.text = null;
        ItemNameText.text = null;
        ItemInformation.SetActive(false);
        //Debug.Log("ClearSlot in Inventory");
    }

    public void RemoveItemFromInventory()
    {
        Inventory.instance.Remove(item);
       
    }

    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
        }
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        if (icon.enabled)
        {
            ItemInformation.SetActive(true);
            //Debug.Log("Show the information!");
        }
        else
        {
            ItemInformation.SetActive(false);
        }
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        ItemInformation.SetActive(false);
        //Debug.Log("Disable the information!");
    }

}
