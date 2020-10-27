using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notice : MonoBehaviour
{
    public GameObject Object;
    public float TimeAnim = 3f;
    private float time;

    public void OnMouseDown()
    {
        if (!Object.activeSelf)
        {
        Object.SetActive(true);
        Object.GetComponent<NoticeClose>().StartCore(TimeAnim);
        }

    }
}
