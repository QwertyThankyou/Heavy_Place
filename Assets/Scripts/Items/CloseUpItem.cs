using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CloseUpItem : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private float cameraViewSize;
    private Collider col;

    private void Start()
    {
        col = GetComponent<Collider>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        col.enabled = false;
        CameraController.instance.SetActiveBackButton(true);
        CameraController.instance.LookAt(transform.position, cameraViewSize, col);
    }
}
