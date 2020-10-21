using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private Dictionary<string, int> items = new Dictionary<string, int>();
    private List<CollectibleItem> collectibles = new List<CollectibleItem>();

    public static Inventory instance;

    public CollectibleItem CurrentlyCheckedItem { get; private set; }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(instance.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddItem(CollectibleItem item)
    {
        if (!collectibles.Contains(item)) collectibles.Add(item);

        if (!items.ContainsKey(item.ItemConfig.ItemId))
        {
            items.Add(item.ItemConfig.ItemId, 1);
        }
        else
        {
            items[item.ItemConfig.ItemId]++;
        }
        InventoryUI.instance.AddOrUpdateItem(item, items[item.ItemConfig.ItemId]);
    }

    public void DisposeItem(CollectibleItem item)
    {
        if (items.ContainsKey(item.ItemConfig.ItemId))
        {
            items[item.ItemConfig.ItemId]--;
            if (items[item.ItemConfig.ItemId] <= 0)
            {
                items.Remove(item.ItemConfig.ItemId);
                var it = collectibles.Find(i => i.ItemConfig.ItemId == item.ItemConfig.ItemId);
                collectibles.Remove(it);
            }
            int amount = items.ContainsKey(item.ItemConfig.ItemId) ? items[item.ItemConfig.ItemId] : 0;
            InventoryUI.instance.GetItem(item.ItemConfig.ItemId).IsChecked = false;
            InventoryUI.instance.AddOrUpdateItem(item, amount);
        }
    }

    public void SetCurrentCheckedItem(string itemId)
    {
        var checkedItem = collectibles.Find(i => i.ItemConfig.ItemId == itemId);
        ResetCurrentCheckedItem();
        if (checkedItem != null)
        {
            CurrentlyCheckedItem = checkedItem;
        }
    }

    public void ResetCurrentCheckedItem()
    {
        CurrentlyCheckedItem = null;
    }

}
