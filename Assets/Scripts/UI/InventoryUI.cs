using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private InventoryItem itemPrefab;
    [SerializeField] private Transform scrollViewContent;

    private List<InventoryItem> inventoryItems = new List<InventoryItem>();
    private InventoryItem currentSelected;

    public static InventoryUI instance;
    public InventoryItem GetItem(string id) => inventoryItems.Find(i => i.ItemId == id);

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void AddOrUpdateItem(CollectibleItem item, int amount)
    {
        InventoryItem inventoryItem = inventoryItems.Find(i => i.ItemId == item.ItemConfig.ItemId);
        if (amount == 0 && inventoryItem != null)
        {
            RemoveItem(inventoryItem);
            return;
        }

        if (inventoryItem != null)
        {
            inventoryItem.Setup(item.ItemConfig.ItemId, amount, item.ItemConfig.InventorySprite);
        }
        else
        {
            inventoryItem = Instantiate(itemPrefab, scrollViewContent);
            inventoryItem.Setup(item.ItemConfig.ItemId, amount, item.ItemConfig.InventorySprite);
            inventoryItems.Add(inventoryItem);
        }
        inventoryItem.onCheckChange += OnItemCheckChange;
    }

    private void RemoveItem(InventoryItem item)
    {
        var goToDestroy = inventoryItems.Find(i => i == item).gameObject;
        inventoryItems.Remove(item);
        Destroy(goToDestroy);
    }

    private void OnItemCheckChange(InventoryItem item)
    {
        if (currentSelected != item)
        {
            if (currentSelected != null) currentSelected.IsChecked = false;
            currentSelected = item;
        }
    }
}
