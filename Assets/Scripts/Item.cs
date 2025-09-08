using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public abstract string ItemName { get; set; }
    public abstract int MoneyValue { get; set; }
}
