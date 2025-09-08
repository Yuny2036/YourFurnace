using UnityEngine;

[CreateAssetMenu(fileName = "PropsData", menuName = "Scriptable Objects/Props n Junks Data")]
public class PropsData : ScriptableObject
{
    [Header("General Stats")]
    public string ItemName = "Default Prop";
    public int Value;
    public int RequiredTrial;
    public int MaximumStacks = 1;
    public GameObject ThisPrefab;

    [Header("Next Item")]
    public GameObject NextItem;

    [Header("Effects")]
    public GameObject EffectOnDestory;

    [Header("Uniqueness and Flavor")]
    public string baseID;
    public string FlavorText;
}
