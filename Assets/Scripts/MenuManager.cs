using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    private void Start()
    {
        Application.targetFrameRate = 60;
    }

    public void OnPlay()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OnQuit()
    {
        Application.Quit();
    }
}
