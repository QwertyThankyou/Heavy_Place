using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseItem : MonoBehaviour
{
    private bool isUsed;
    private bool isVisible;
    private bool isLoadingData;
    public float[] Position => new float[3] { transform.localPosition.x, transform.localPosition.y, transform.localPosition.z };
    public float[] Rotation => new float[4] { transform.localRotation.x, transform.localRotation.y, transform.localRotation.z, transform.localRotation.w };
    public bool IsUsed { get { return isUsed; } set { isUsed = value; SaveData(); } }
    public bool IsVisible { get { return isVisible; } set { isVisible = value; SaveData(); } }
    public string Id => string.Format("{0}.{1}[{2},{3},{4}]", "TEMP", name, Position[0], Position[1], Position[2]);
    protected void SaveData()
    {
        if (isLoadingData) return;
        //qqq
    }

    protected abstract void PrepareItem();

    public void LoadData(ItemData data)
    {
        //qqq
        isLoadingData = true;
        if (data != null)
        {
            transform.localPosition = new Vector3(data.position[0], data.position[1], data.position[2]);
            transform.localRotation = new Quaternion(data.rotation[0], data.rotation[1], data.rotation[2], data.rotation[3]);
            isUsed = data.isUsed;
            isVisible = data.isVisible;
        }
        else
        {
            IsUsed = false;
            IsVisible = true;
        }
        isLoadingData = false;
        PrepareItem();
    }
}