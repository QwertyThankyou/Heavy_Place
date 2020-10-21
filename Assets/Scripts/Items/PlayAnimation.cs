using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation : MonoBehaviour
{
    public GameObject Object;
    public float TimeAnim = 10f;
    public GameObject EnableObj;

    public void OnMouseDown()
    {
        Object.GetComponent<Animator>().SetBool("Bool", true);
        if (EnableObj != null)
        {
            EnableObj.SetActive(true);
        }
        StartCoroutine(DisableAnimator());
    }

    IEnumerator DisableAnimator()
    {
        yield return new WaitForSeconds(TimeAnim);
        Object.GetComponent<Animator>().enabled = false;
    }
}
