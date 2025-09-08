using UnityEngine;
using UnityEngine.EventSystems;

public class PropsItemInstance : ItemInstance
{
    // ItemType specific fields
    public PropsData baseData; // ScriptableObjects

    // public int MaximumStacks;
    public int CurrentStacks;

    public PropsItemInstance(PropsData baseData) : this(baseData, 1)
    {
        
    }

    public PropsItemInstance(PropsData baseData, int CurrentStacks)
    {
        this.baseData = baseData;
        this.CurrentStacks = CurrentStacks;
    }
}
