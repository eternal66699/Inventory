using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerializableValuePair<Tkey, TValue>
{
    public Tkey Key;
    public TValue Value;

    public SerializableValuePair(Tkey key, TValue value)
    {
        Key = key;
        Value = value;
    }
}

public class InventorySystem : MonoBehaviour
{
    [SerializeField]
    private Dictionary<int, Items> inventory = new Dictionary<int, Items>();
    [SerializeField]
    List<SerializableValuePair<int, Items>> inventoryList = new List<SerializableValuePair<int, Items>>();

    public void SyncListWithDictionary()
    {
        inventoryList.Clear();
        foreach(var pair in inventory)
        {
            inventoryList.Add(new SerializableValuePair<int, Items>(pair.Key, pair.Value));
        }
    }
    public void AddItem(Items item)
    {
        if (inventory.ContainsKey(item.ID))
        {
            //update the quantity
        }
        else
        {
            inventory.Add(item.ID, item);
        }
        SyncListWithDictionary();
    }
    public bool RemoveItem(int itemID)
    {
        bool _remove = inventory.Remove(itemID);
        if (_remove)
        {
            SyncListWithDictionary();
        }
        return _remove;
    }
    public bool CheckItem(int itemID)
    {
        return inventory.ContainsKey(itemID);
    }
}
