using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorItem : UsableItem
{
    [SerializeField] private Color colorToChange;
    [SerializeField] private MeshRenderer meshRenderer;

    protected override void Use()
    {
        meshRenderer.material.color = colorToChange;
        isUsed = true;
    }
}
