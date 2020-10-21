using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public bool Pause { get; set; }
    public string CurrentSceneName => SceneManager.GetActiveScene().name;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    instance = new GameObject("GameManager").AddComponent<GameManager>();
                }
                DontDestroyOnLoad(instance.gameObject);
            }
            return instance;
        }
    }


}