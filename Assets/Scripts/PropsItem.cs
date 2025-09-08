using System;
using UnityEngine;

public abstract class PropsItem : Item
{
    // Serialized Fields
    [SerializeField] protected PropsData propsData;
    // Properties
    public override string ItemName
    {
        get => _ItemName;
        set
        {
            if (!string.IsNullOrWhiteSpace(value)) _ItemName = value;
        }
    }
    public override int MoneyValue
    {
        get => _MoneyValue;
        set
        {
            _MoneyValue = Math.Max(0, value);
        }
    }

    // Unity Lifecycle
    void Start()
    {
        // Initialize item
        ItemName = propsData.ItemName;
        MoneyValue = propsData.Value;
    }

    // Internal fields
    private string _ItemName;
    private int _MoneyValue;
}
