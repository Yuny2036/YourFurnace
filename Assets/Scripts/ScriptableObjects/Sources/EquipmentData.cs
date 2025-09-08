using System;
using UnityEngine;

[CreateAssetMenu(fileName = "EquipmentData", menuName = "Scriptable Objects/Equipment Data")]
public class EquipmentData : ScriptableObject
{
    [Header("General Stats")]
    public string ItemName = "Default Equipment";
    public int Value;
    public GameObject ThisPrefab;

    [Header("Equipment Specific Values")]
    public int RequiredTrial;
    public int EquipmentRank;
    public float EnhanceChance;

    [Header("Next Item")]
    public GameObject NextItem;

    [Header("Effects")]
    public GameObject Effect = null;
    public GameObject FailureEffect = null;

    [Header("Uniqueness and Flavor")]
    public string FlavorText;
}
