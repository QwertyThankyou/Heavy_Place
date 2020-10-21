using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image background;
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI amountText;

    private bool isChecked;
    public bool IsChecked { get { return isChecked; } set { isChecked = value; SetChecked(); } }

    public string ItemId { get; private set; }
    public Action<InventoryItem> onCheckChange;

    public void Setup(string itemId, int amount, Sprite sprite)
    {
        ItemId = itemId;
        amountText.text = amount <= 1 ? string.Empty : amount.ToString();
        image.sprite = sprite;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Inventory.instance.CurrentlyCheckedItem?.ItemConfig.ItemId != ItemId)
        {
            Inventory.instance.SetCurrentCheckedItem(ItemId);
            IsChecked = true;
        }
        else
        {
            Inventory.instance.ResetCurrentCheckedItem();
            IsChecked = false;
        }
    }

    private void SetChecked()
    {
        onCheckChange?.Invoke(this);
        Color color = background.color;
        color.a = IsChecked ? 0.5f : 0f;
        background.color = color;
    }
}
