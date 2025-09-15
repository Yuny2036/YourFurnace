using UnityEngine;

[CreateAssetMenu(fileName = "EquipmentData", menuName = "Scriptable Objects/Equipment Data")]
public class EquipmentData : ItemData
{
    [Header("Equipment Specifics")]
    public int EquipmentRank;
    public float EnhanceChance;

    [Header("Effects")]
    public GameObject Effect = null;
}
