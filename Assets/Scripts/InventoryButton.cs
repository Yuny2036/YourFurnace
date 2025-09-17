using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour
{
    public ItemInstance ItemInstance { get; set; }
    private TextMeshProUGUI _textMeshPro;
    private Button _button;

    void Start()
    {
        _textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
        if (_textMeshPro != null) _textMeshPro.text = ItemInstance.ItemName;

        _button = GetComponent<Button>();
        if (_button != null) _button.onClick.AddListener(PulledOut);
    }

    public void PulledOut()
    {
        InventoryManager.InventoryInstance.TakeFromInventory(ItemInstance);
    }
}
