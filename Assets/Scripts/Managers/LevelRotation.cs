using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelRotation : MonoBehaviour
{
    [SerializeField] private Transform level;
    [SerializeField] private float rotationTime = 0.5f;
    [SerializeField] private float wallsAnimationTime = 0.25f;
    [SerializeField] private float changeYPosition = 10f;

    [SerializeField] private WallController upWall;
    [SerializeField] private WallController leftWall;
    [SerializeField] private WallController bottomWall;
    [SerializeField] private WallController rightWall;

    private RotationSide rotationSide = RotationSide.Bottom;
    private bool rotating = false;
    private bool pressingMouse = false;
    private float startPosX;

    public static LevelRotation instance;
    public bool IsLocked = false; // is locked
    public float ChangeYPosition => changeYPosition;
    public float WallAnimationTime => wallsAnimationTime;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        ChangeWallsPosition();
    }

    private void Update()
    {
        CheckRotation();
    }

    private void CheckRotation()
    {
        if (GameManager.Instance.Pause || IsLocked) return; // Вот тут Запомни
        float mousePosX = Input.mousePosition.x;

        if (rotating) return;

        if (Input.GetMouseButtonDown(0))
        {
            pressingMouse = true;
            startPosX = mousePosX;
        }
        if (pressingMouse && Input.GetMouseButtonUp(0))
        {
            pressingMouse = false;
            if (mousePosX < startPosX && Mathf.Abs(mousePosX - startPosX) > Screen.width * 0.08f) // сколько нужно чирнкнуть пальцем для свайпа
            {
                StartCoroutine(Rotate(Vector3.up, 90));
            }
            else if (mousePosX > startPosX && Mathf.Abs(mousePosX - startPosX) > Screen.width * 0.08f) // сколько нужно чирнкнуть пальцем для свайпа
            {
                StartCoroutine(Rotate(Vector3.up, -90));
            }
        }
    }

    private IEnumerator Rotate(Vector3 axis, float angle)
    {
        rotating = true;
        Quaternion from = level.rotation;
        Quaternion to = level.rotation * Quaternion.Euler(axis * angle);
        CheckAndSetSide(to);

        float elapsed = 0.0f;
        while (elapsed < rotationTime)
        {
            level.rotation = Quaternion.Slerp(from, to, elapsed / rotationTime);
            elapsed += Time.deltaTime;
            yield return null;
        }
        level.rotation = to;
        rotating = false;
    }
    private void CheckAndSetSide(Quaternion toRot)
    {
        switch (toRot.eulerAngles.y)
        {
            case 0f: rotationSide = RotationSide.Bottom; break;
            case 90f: rotationSide = RotationSide.Right; break;
            case 180f: rotationSide = RotationSide.Up; break;
            case 270f: rotationSide = RotationSide.Left; break;
        }
        ChangeWallsPosition();
    }

    private void ChangeWallsPosition()
    {
        switch (rotationSide)
        {
            case RotationSide.Bottom:
                bottomWall.IsVisible = false; rightWall.IsVisible = false;
                upWall.IsVisible = true; leftWall.IsVisible = true; break;
            case RotationSide.Up:
                upWall.IsVisible = false; leftWall.IsVisible = false;
                bottomWall.IsVisible = true; rightWall.IsVisible = true; break;
            case RotationSide.Left:
                bottomWall.IsVisible = false; leftWall.IsVisible = false;
                upWall.IsVisible = true; rightWall.IsVisible = true; break;
            case RotationSide.Right:
                upWall.IsVisible = false; rightWall.IsVisible = false;
                bottomWall.IsVisible = true; leftWall.IsVisible = true; break;
        }
    }
}

public enum RotationSide
{

    Up, Left, Bottom, Right
}