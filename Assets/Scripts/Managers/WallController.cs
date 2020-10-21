using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    [SerializeField] private GameObject container;
    private bool isVisible;

    public bool IsVisible
    {
        get { return isVisible; }
        set
        {
            isVisible = value;
            if (value == true)
            {
                container.SetActive(true);
            }
            StartCoroutine(Change());
        }
    }

    private IEnumerator Change()
    {
        float estimated = 0f;
        float changeTime = LevelRotation.instance.WallAnimationTime;
        float maxY = LevelRotation.instance.ChangeYPosition;

        if (isVisible && container.transform.position.y == 0) yield break;
        if (!isVisible && container.transform.position.y == maxY) yield break;

        while (estimated < changeTime)
        {
            estimated += Time.deltaTime;
            if (!isVisible)
            {
                container.transform.position = Vector3.up * estimated / changeTime * maxY;
            }
            else
            {
                container.transform.position = Vector3.up * (1 - (estimated / changeTime)) * maxY;
            }
            yield return null;
        }
        if (!IsVisible)
        {
            container.transform.position = Vector3.up * maxY;
            container.SetActive(false);
        }
        else
        {
            container.transform.position = Vector3.zero;
        }
    }
}
