using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public static bool InventoryIsOpened = false;
    public GameObject inventoryUI;
    public Transform itemsParent;
    private string MoneyRemaining;
    public Text MoneyText;
    //private ViewChanger viewChanger;

    Inventory inventory;

    // Use this for initialization
    void Start()
    {
        //viewChanger= FindObjectOfType<ViewChanger>();

        inventory = Inventory.instance;
        inventory.OnItemChangedCallback += UpdateUI;
    }

    // Update is called once per frame
    void Update()
    {
        MoneyRemaining = "" + inventory.Money;
        MoneyText.text = MoneyRemaining;

        if (Input.GetButtonDown("Inventory"))
        {
            if (GameManager.currentState == GameManager.GameState.EGamePlay)
            {
                if (InventoryIsOpened == false)
                {
                    GameManager.InventoryUI.enabled = true;
                    AudioManager.instance.Play("InventoryOpen");
                    InventoryIsOpened = true;
                    //Debug.Log("inventoryUIIsActive");
                    UpdateUI();
                }
                else
                {
                    GameManager.InventoryUI.enabled = false;
                    AudioManager.instance.Play("InventoryClose");
                    //viewChanger.GamePlay();
                    InventoryIsOpened = false;

                }
            }
        }
    }
       

    public void UpdateUI()
    {

        InventorySlot[] slots = GetComponentsInChildren<InventorySlot>();
        //Debug.Log(slots.Length);

        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].ShowItem(inventory.items[i]);
                           
                //Debug.Log("UpdateUI");

            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
