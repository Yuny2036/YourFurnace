using System;
using UnityEngine;

public class EquipmentItemInstance : ItemInstance
{
    // ItemType specific fields
    public EquipmentData baseData; // ScriptableObjects

    // [Header("Uniqueness and Flavor")]
    public Guid UniqueID;
    // public string FlavorText;

    public EquipmentItemInstance(string ItemName, int MoneyValue, GameObject ThisPrefab) : this(ItemName, MoneyValue, ThisPrefab, Guid.NewGuid())
    {

    }

    public EquipmentItemInstance(string ItemName, int MoneyValue, GameObject ThisPrefab, Guid UniqueID) : base(ItemName, MoneyValue, ThisPrefab)
    {
        this.UniqueID = UniqueID;
    }
}
