﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void LaunchLevel1()
    {
        StartCoroutine(LoadLevel1Async());
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    IEnumerator LoadLevel1Async()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Level1");

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

}
