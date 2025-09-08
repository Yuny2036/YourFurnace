using UnityEngine;

public abstract class ItemInstance
{
    // [Header("General Stats")]
    public string ItemName { get; set; }
    public int MoneyValue { get; set; }
    public GameObject ThisPrefab;

    // [Header("Uniqueness and Flavor")]
    public string FlavorText = "<Place Holder>";
}
