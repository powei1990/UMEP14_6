using UnityEngine;

[CreateAssetMenu(fileName ="New Item",menuName ="Inventory/Item")]
public class Item : ScriptableObject {
    new public string ItemName = "New Item";
    public Sprite icon = null;
    public bool isSackItem = false;
    public int Cost;
 
    [TextArea(3, 10)]
    public string Description = null;

    
    public virtual void Use()
    {
        Debug.Log("Using" + ItemName);
    }

    public void Sell()
    {
        Inventory.instance.Money += Cost/2+2;
        RemoveFromInventory();
        AudioManager.instance.Play("Sell&BuyItem");
    }
public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    }
}
