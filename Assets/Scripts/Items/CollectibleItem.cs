using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CollectibleItem : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Item itemConfig;
    [SerializeField] private GameObject visual;

    public Item ItemConfig => itemConfig;
    private Collider objectCollider;

    private void Start()
    {
        objectCollider = GetComponent<Collider>();
    }

    private void SetActiveVisual(bool isActive)
    {
        visual.SetActive(isActive);
        objectCollider.enabled = isActive;
    }

    public void Dispose()
    {
        Inventory.instance.DisposeItem(this);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (GameManager.Instance.Pause) return;

        Inventory.instance.AddItem(this);
        SetActiveVisual(false);
    }
}
