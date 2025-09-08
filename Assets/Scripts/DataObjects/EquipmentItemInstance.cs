using System;
using UnityEngine;

public class EquipmentItemInstance : ItemInstance
{
    // ItemType specific fields
    public EquipmentData baseData; // ScriptableObjects

    // [Header("Uniqueness and Flavor")]
    public Guid UniqueID;
    // public string FlavorText;

    public EquipmentItemInstance(EquipmentData baseData) : this(baseData, Guid.NewGuid())
    {

    }

    public EquipmentItemInstance(EquipmentData baseData, Guid UniqueID)
    {
        this.baseData = baseData;
        this.UniqueID = UniqueID;
    }
}
