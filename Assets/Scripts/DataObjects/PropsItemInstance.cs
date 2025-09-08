using UnityEngine;
using UnityEngine.EventSystems;

public class PropsItemInstance : ItemInstance
{
    // ItemType specific fields
    public PropsData baseData; // ScriptableObjects

    // public int MaximumStacks;
    public int CurrentStacks;

    public PropsItemInstance(string ItemName, int MoneyValue, GameObject ThisPrefab) : this(ItemName, MoneyValue, ThisPrefab, 1)
    {
        
    }

    public PropsItemInstance(string ItemName, int MoneyValue, GameObject ThisPrefab, int CurrentStacks) : base(ItemName, MoneyValue, ThisPrefab)
    {
        this.CurrentStacks = CurrentStacks;
    }
}
