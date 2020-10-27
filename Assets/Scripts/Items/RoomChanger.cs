using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomChanger : MonoBehaviour
{
    public int NextSceneNumber;

    public void OnMouseUp()
    {
        SceneManager.LoadScene(NextSceneNumber);
    }
}
