using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public void LaunchLevel1()
    {
        Debug.Log("Launch level 1");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
