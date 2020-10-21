using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Game Data/New Item")]
public class Item : ScriptableObject
{
    [SerializeField] private string itemId;
    [SerializeField] private string displayName;
    [SerializeField] private Sprite inventorySprite;

    public string ItemId => itemId;
    public string DisplayName => displayName;
    public Sprite InventorySprite => inventorySprite;
}
