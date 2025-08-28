using UnityEngine;

[CreateAssetMenu(fileName = "EquipmentData", menuName = "Scriptable Objects/Equipment Data")]
public class EquipmentData : ScriptableObject
{
    [Header("General Stats")]
    public string ItemName = "Default Equipment";
    public int Value;

    [Header("Equipment Specific Values")]
    public int RequiredTrial;
    public int EquipmentRank;
    public float EnhanceChance;

    [Header("Next Item")]
    public GameObject NextItem;
}
