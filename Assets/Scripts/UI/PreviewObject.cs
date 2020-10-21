using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreviewObject : MonoBehaviour
{
    [SerializeField] private Button exitButton;
    [SerializeField] private GameObject contentToShow;
    [SerializeField] private GameObject background;

    private void Start()
    {
        exitButton.onClick.RemoveAllListeners();
        exitButton.onClick.AddListener(() => { SetActive(false); });
    }

    public void SetActive(bool value)
    {
        GameManager.Instance.Pause = value;
        contentToShow.SetActive(value);
        background.SetActive(value);
    }
}
