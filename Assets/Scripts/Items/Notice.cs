using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notice : MonoBehaviour
{
    public GameObject Object;
    public float TimeAnim = 2f;
    private float time;

    public void OnMouseDown()
    {
        if (!Object.activeSelf)// если повернуть камеру во время того как 2 секунды ещё не прошли, то эта штука зациклится навечно.
        {
        Object.SetActive(true);
        StartCoroutine(DisableObject());
        }

    }

    IEnumerator DisableObject()
    {
        yield return new WaitForSeconds(TimeAnim);
        Object.SetActive(false);
    }
}
