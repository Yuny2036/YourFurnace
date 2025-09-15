using UnityEngine;

[CreateAssetMenu(fileName = "PropsData", menuName = "Scriptable Objects/Props n Junks Data")]
public class PropsData : ItemData
{
    [Header("Consumable Specifics")]
    public int MaximumStacks = 1;
    public string baseID;
}
