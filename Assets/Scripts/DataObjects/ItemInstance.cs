using UnityEngine;

public abstract class ItemInstance
{
    // [Header("General Stats")]
    public string ItemName;
    public int MoneyValue;
    public GameObject ThisPrefab;

    // [Header("Uniqueness and Flavor")]
    public string FlavorText = "<Place Holder>";

    public ItemInstance(string ItemName, int MoneyValue, GameObject ThisPrefab)
    {
        this.ItemName = ItemName;
        this.MoneyValue = MoneyValue;
        this.ThisPrefab = ThisPrefab;
    }
}
