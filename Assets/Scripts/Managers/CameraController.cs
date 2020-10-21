using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float transitionTime = 0.5f;
    [SerializeField] private Button cameraBackButton;

    private Camera camera;

    public LevelRotation LvlRot; // lvl rot наш
    private Quaternion startRotation;
    private float startViewSize;
    private Collider currentlyDisabledCollider;

    public static CameraController instance;
    public bool IsZoomed { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        camera = GetComponent<Camera>();
        startRotation = transform.rotation;
        startViewSize = camera.orthographicSize;
        cameraBackButton.onClick.AddListener(BackToStartPosition);
    }

    public void SetActiveBackButton(bool value)
    {
        cameraBackButton.gameObject.SetActive(value);
    }

    public void LookAt(Vector3 objectPosition, float size, Collider colToEnable)
    {
        if (currentlyDisabledCollider != null)
        {
            currentlyDisabledCollider.enabled = true;
        }
        currentlyDisabledCollider = colToEnable;
        StartCoroutine(LookAtCoroutine(objectPosition, size));
    }

    private IEnumerator LookAtCoroutine(Vector3 objectPosition, float size)
    {
        //Из локед = тру
        LvlRot.IsLocked = true;
        Quaternion startRot = transform.rotation;
        Quaternion endRot = Quaternion.LookRotation(objectPosition - transform.position);
        float startSize = camera.orthographicSize;

        float estimated = 0f;

        while (estimated < transitionTime)
        {
            transform.rotation = Quaternion.Slerp(startRot, endRot, estimated / transitionTime);
            camera.orthographicSize = Mathf.SmoothStep(startSize, size, estimated / transitionTime);
            estimated += Time.deltaTime;
            yield return null;
        }
        IsZoomed = true;
    }

    private IEnumerator BackToStart()
    {
        //is locked = false
        LvlRot.IsLocked = false;
        Quaternion startRot = transform.rotation;
        float startSize = camera.orthographicSize;
        float estimated = 0f;

        while (estimated < transitionTime)
        {
            transform.rotation = Quaternion.Slerp(startRot, startRotation, estimated / transitionTime);
            camera.orthographicSize = Mathf.SmoothStep(startSize, startViewSize, estimated / transitionTime);
            estimated += Time.deltaTime;
            yield return null;
        }
        IsZoomed = false;
    }

    private void BackToStartPosition()
    {
        if (currentlyDisabledCollider != null)
        {
            currentlyDisabledCollider.enabled = true;
        }
        SetActiveBackButton(false);
        StartCoroutine(BackToStart());
    }
}
