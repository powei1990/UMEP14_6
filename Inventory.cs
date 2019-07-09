using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }
        instance = this;
    }
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged OnItemChangedCallback;

    public int Money = 0;
    public int RedPosionAmount = 20;
    public int space = 30;

    public List<Item> items = new List<Item>();

    public bool Add(Item item)
    {
        if (!item.isSackItem)
        {
            if (items.Count >= space)
            {
                Debug.LogWarning("Not enough room.");
                return false;

            }

            items.Add(item);
            //Debug.Log();
            if (OnItemChangedCallback != null)
                OnItemChangedCallback.Invoke();
        }
        else
        {
            if(!items.Exists(x => x.ItemName == item.ItemName))
            {
                items.Add(item);
            }
            else
            {
                //Debug.Log(item.Amount);
            }

        }
        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);     // Remove item from list

        //Trigger callback
        if (OnItemChangedCallback != null)
            OnItemChangedCallback.Invoke();
    }

}