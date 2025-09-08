using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

    // Methods
    public void PutInInventory(ItemInstance itemInstance)
    {
        switch (itemInstance)
        {
            case EquipmentItemInstance eii:
                // Is the exactly same item already in the inventory?
                if (InventoryList.Contains(eii)) throw new ArgumentException("You're trying to put the exact same entity in. How did you do..?");
                PutItemInNewSlot(eii);

                // if (!InventoryList.Any(item => item is EquipmentItemInstance existingItem && existingItem.UniqueID == eii.UniqueID))
                break;

            case PropsItemInstance pii:
                // Get the existing item from the inventory.
                var existingItem = InventoryList
                .OfType<PropsItemInstance>()
                .FirstOrDefault(item => item.baseData.baseID == pii.baseData.baseID);

                // When there's the item.
                if (existingItem != null)
                {
                    // Calculate how many stack can be added into the existing one.
                    int stackLeft = existingItem.baseData.MaximumStacks - existingItem.CurrentStacks;

                    // Space left is bigger than one you're trying?
                    // If yes,
                    if (pii.CurrentStacks <= stackLeft)
                    {
                        existingItem.CurrentStacks += pii.CurrentStacks;
                    }
                    // If no,
                    else
                    {
                        existingItem.CurrentStacks += stackLeft;

                        // Get remaining items' count.
                        var remainingItem = new PropsItemInstance(pii.baseData, pii.CurrentStacks - stackLeft);

                        // Put em in the new slot
                        PutItemInNewSlot(remainingItem);
                    }
                }
                else
                {
                    PutItemInNewSlot(pii);
                }
                break;

                // ======
                // The code scraps are the trace of my trials and errors.
                // ======
                // if (!InventoryList.Any(item => item is PropsItemInstance))
                // {
                //     if (InventoryList.Count >= 5) throw new ArgumentOutOfRangeException("Inventory is full; Maximum is 4.");

                //     InventoryList.Add(pii);
                // }
                // else if (
                //     InventoryList.Any(item => item is PropsItemInstance existingItem &&
                //     existingItem.baseData.ItemName == pii.baseData.ItemName)
                //     )
                // {

                // }
                // break;
        }
    }

    public void TakeFromInventory(ItemInstance itemInstance)
    {
        switch (itemInstance)
        {
            case EquipmentItemInstance eii:
                RemoveItemFromInventory(eii);
                break;
            case PropsItemInstance pii:
                if (pii.CurrentStacks - 1 > 0)
                {
                    pii.CurrentStacks--;
                }
                else
                {
                    RemoveItemFromInventory(pii);
                }
                break;
        }
    }

    private void RemoveItemFromInventory(ItemInstance itemInstance)
    {
        // Sorry, My laziness makes me not to create a new ToString() format..
        if (!InventoryList.Contains(itemInstance)) throw new NullReferenceException($"There's no such item to discard. How did you do..? : {itemInstance}");
        InventoryList.Remove(itemInstance);
    }

    private void PutItemInNewSlot(ItemInstance itemInstance)
    {
        if (InventoryList.Count >= 5) throw new ArgumentOutOfRangeException("Inventory is full; Maximum is 4.");

        InventoryList.Add(itemInstance);
    }

    

    // Internal fields
    private static InventoryManager _InventoryInstance;
}
