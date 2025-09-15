using TMPro;
using UnityEngine;

public class InventoryButton : MonoBehaviour
{
    public ItemInstance ItemInstance { get; set; }
    private TextMeshPro _textMeshPro;

    void Start()
    {
        _textMeshPro.text = ItemInstance.ItemName;
    }
}
