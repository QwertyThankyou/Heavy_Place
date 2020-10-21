using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class UsableItem : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private bool needsInteractableItem;
    [SerializeField] private Item interactableItem;

    protected bool isUsed = false;

    public void Use(CollectibleItem item)
    {
        if (isUsed) return;

        if (item == null || item.ItemConfig.ItemId != interactableItem.ItemId)
        {
            Debug.LogErrorFormat("Примените предмет", interactableItem.DisplayName);
            return;
        }

        if (item.ItemConfig.ItemId == interactableItem.ItemId)
        {
            item.Dispose();
            Use();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (needsInteractableItem)
        {
            Use(Inventory.instance.CurrentlyCheckedItem);
        }
        else
        {
            Use();
        }
    }

    protected virtual void Use() { }
}
