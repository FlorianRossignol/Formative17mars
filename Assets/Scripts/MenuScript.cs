﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
   public void StartGame()
    {
        SceneManager.LoadScene("Stage1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}