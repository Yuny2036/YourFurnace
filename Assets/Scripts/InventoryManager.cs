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
    readonly List<ItemInstance> InventoryList = new List<ItemInstance>();
    [SerializeField] private GameObject characterPanel;
    private GameObject itemButtonPrefab;


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

        itemButtonPrefab = Resources.Load<GameObject>("ItemButton");
    }

    // Methods
    public void PutInInventory(ItemInstance itemInstance)
    {
        switch (itemInstance)
        {
            case EquipmentItemInstance eii:
                Debug.LogWarning($"2 {eii.ItemName}, {eii.UniqueID}");
                if (InventoryList.Contains(eii)) throw new ArgumentException("You're trying to put the exact same entity in. How did you do..?");
                PutItemInNewSlot(eii);

                break;

            case PropsItemInstance pii:
                Debug.LogWarning("2 Props");
                var existingItem = InventoryList
                .OfType<PropsItemInstance>()
                .Where(p => p.baseData.baseID == pii.baseData.baseID)
                .ToList();
                // .FirstOrDefault(item => item.baseData.baseID == pii.baseData.baseID);

                if (existingItem.Count != 0)
                {
                    int spaceLeft;
                    foreach (var prop in existingItem)
                    {
                        spaceLeft = prop.baseData.MaximumStacks - prop.CurrentStacks;

                        if (spaceLeft <= 0) continue;

                        if (pii.CurrentStacks <= spaceLeft)
                        {
                            prop.CurrentStacks += pii.CurrentStacks;
                        }
                        else
                        {
                            prop.CurrentStacks += spaceLeft;

                            var remainingItem = new PropsItemInstance(pii.baseData, pii.CurrentStacks - spaceLeft);

                            PutItemInNewSlot(remainingItem);
                        }
                    }
                }
                else
                {
                    PutItemInNewSlot(pii);
                }
                break;
        }

        ShowItemInInventory();
    }

    public void TakeFromInventory(ItemInstance itemInstance)
    {
        switch (itemInstance)
        {
            case EquipmentItemInstance eii:
                GameObject eiGameObject = Instantiate(eii.ThisPrefab, dropPosition.position, dropPosition.rotation);
                eiGameObject.TryGetComponent<EquipmentItem>(out var ei);
                if (ei != null)
                {
                    ei.TransferData(eii);
                    RemoveItemFromInventory(eii);
                }
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
                GameObject piGameObject = Instantiate(pii.ThisPrefab, dropPosition.position, dropPosition.rotation);
                break;
        }

        foreach (var item in InventoryList)
        {
            Debug.LogWarning($"{item.ItemName}");
        }

        ShowItemInInventory();
    }

    private void RemoveItemFromInventory(ItemInstance itemInstance)
    {
        if (!InventoryList.Contains(itemInstance)) throw new NullReferenceException($"There's no such item to discard. How did you do..? : {itemInstance}");
        InventoryList.Remove(itemInstance);
    }

    private void PutItemInNewSlot(ItemInstance itemInstance)
    {
        if (InventoryList.Count > maximumSize) throw new ArgumentOutOfRangeException($"Inventory is full; Maximum is {maximumSize}");

        InventoryList.Add(itemInstance);
    }

    private void ShowItemInInventory()
    {
        Debug.LogWarning($"3 {InventoryList.Count} of items are in.");

        // Destory all before re-render
        for (int i = characterPanel.transform.childCount - 1; i >= 0; i--)
        {
            Transform child = characterPanel.transform.GetChild(i);
            if (child.tag == "InventoryItemButton") Destroy(child.gameObject);
        }

        foreach (var item in InventoryList)
        {
            GameObject prefab = Instantiate(itemButtonPrefab, characterPanel.transform);
            prefab.TryGetComponent<InventoryButton>(out var iButton);
            if (iButton != null) iButton.ItemInstance = item;
        }

        
    }


    // Internal fields
    private static InventoryManager _InventoryInstance;
    [SerializeField] private Transform dropPosition;
    private int maximumSize = 4;
}
