using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PreviewableItem : BaseItem, IPointerClickHandler
{
    [SerializeField] private PreviewObject previewObject;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (GameManager.Instance.Pause) return;
        previewObject.SetActive(true);
    }

    protected override void PrepareItem() { }
}
