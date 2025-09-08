using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    // Singleton Instance
    public static InventoryManager InventoryInstance
    {
        get
        {
            _InventoryInstance ??= FindAnyObjectByType<InventoryManager>(); // Is Null?
            return _InventoryInstance;
        }
    }

    // Properties and Fields
    readonly List<ItemInstance> InventoryList = new();

    // Unity Lifecycle
    void Awake()
    {
        // Singleton initialization
        if (_InventoryInstance != null && _InventoryInstance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _InventoryInstance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PutInInventory(ItemInstance itemInstance)
    {
        if (InventoryList.Count >= 5) throw new ArgumentOutOfRangeException("You can not hold more than 4 item(slot)s");

        switch (itemInstance)
        {
            case EquipmentItemInstance eii:
                if (!InventoryList.Any(item => item is EquipmentItemInstance itemInInventory && itemInInventory.UniqueID != eii.UniqueID))
                {
                    InventoryList.Add(eii);
                }
                else
                {
                    if (InventoryList.Count >= 5) throw new ArgumentException("You're trying to put the exact same entity in. How did you do..?");
                }
                break;
            case PropsItemInstance pii:
                if (!InventoryList.Any(item => item is PropsItemInstance))
                {
                    InventoryList.Add(pii);
                }
                else if (InventoryList.Any(
                    item => item is PropsItemInstance itemInInventory &&
                    itemInInventory.CurrentStacks + pii.CurrentStacks <= itemInInventory.baseData.MaximumStacks
                    ))
                {
                    var itemInInventory = InventoryList.Find(item => item is PropsItemInstance);
                }
                break;
        }
    }

    public void TakeFromInventory()
    {

    }

    // Internal fields
    private static InventoryManager _InventoryInstance;
}
