using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemData
{
    public float[] position;
    public float[] rotation;
    public bool isUsed;
    public bool isVisible;

    public ItemData(BaseItem item)
    {
        position = item.Position;
        rotation = item.Rotation;
        isUsed = item.IsUsed;
        isVisible = item.IsVisible;
    }
}
