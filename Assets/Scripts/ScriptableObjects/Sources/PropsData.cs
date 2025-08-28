using UnityEngine;

[CreateAssetMenu(fileName = "PropsData", menuName = "Scriptable Objects/Props n Junks Data")]
public class PropsData : ScriptableObject
{
    [Header("General Stats")]
    public string itemName = "Default Prop";
    public int value;
    public int RequiredTrial;

    [Header("Next Item")]
    public GameObject NextItem;
}
