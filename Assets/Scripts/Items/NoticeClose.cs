using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoticeClose : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void StartCore(float TimeAnim)
    {
        StartCoroutine(DisableObject(TimeAnim));
    }
    IEnumerator DisableObject(float TimeAnim)
    {
        yield return new WaitForSeconds(TimeAnim);
        gameObject.SetActive(false);
    }
}
