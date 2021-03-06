using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManagerStage2 : MonoBehaviour
{
    //Handle Stage 2
    
    [SerializeField] private GameObject[] enemy;
    [SerializeField] private GameObject pausingGameobject;
    
    void Update()
    {
        enemy = GameObject.FindGameObjectsWithTag("enemy");

        if (enemy.Length == 0)
        {
            SceneManager.LoadScene("Stage3");
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            StartingPausingMenu();
        }
    }

    private void StartingPausingMenu()
    {
        pausingGameobject.SetActive(true);
        Time.timeScale = 0;
        Cursor.visible = true;
    }

    public void ReturnGame()
    {
        Time.timeScale = 1;
        pausingGameobject.SetActive(false);
        Cursor.visible = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
