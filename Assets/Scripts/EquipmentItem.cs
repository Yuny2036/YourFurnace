using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

public abstract class EquipmentItem : Item, IHammerable
{
    // Serialized Fields
    [SerializeField] public EquipmentData equipmentData;
    // Properties
    public override string ItemName
    {
        get => _ItemName;
        set
        {
            if (!string.IsNullOrWhiteSpace(value)) _ItemName = value;
        }
    }
    public override int MoneyValue
    {
        get => _MoneyValue;
        set
        {
            _MoneyValue = Math.Max(0, value);
        }
    }
    public Guid UniqueID { get; private set; }
    public int HammerTrial { get; set; } // No need to be stored when going into the inventory.

    // Methods
    // Call Initializer() in child's Start()
    protected void Initializer()
    {
        // Initialize item
        // This is the same element you should return, when you take it from the inventory.
        if (UniqueID == null)
        {
            UniqueID = Guid.NewGuid();

            // If you don't need enchanting/name or something, then these don't have to be placed here; go out of block.
            ItemName = equipmentData.ItemName;
            MoneyValue = equipmentData.Value;
        }
        HammerTrial = equipmentData.RequiredTrial;
    }

    public virtual void Hammer()
    {
        if (equipmentData == null) throw new NullReferenceException($"No equipment data has been set on {gameObject}.");
        if (equipmentData.NextItem == null)
        {
            Debug.Log("This item is on top of its maximum potential!");
            return;
        }
    }

    public override ItemInstance ToItemInstance()
    {
        ItemInstance itemInstance = new EquipmentItemInstance(equipmentData, UniqueID);
        itemInstance.ItemName = ItemName;
        itemInstance.MoneyValue = MoneyValue;

        // Debug.LogWarning($"{equipmentData}, {equipmentData.ItemName}");

        return itemInstance as EquipmentItemInstance;
    }

    // Internal fields
    private string _ItemName;
    private int _MoneyValue;
}
