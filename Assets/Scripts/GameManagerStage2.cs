using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManagerStage2 : MonoBehaviour
{
    
    [SerializeField] private GameObject[] enemy;
    [SerializeField] private GameObject PausingGameobject_;

   

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
        PausingGameobject_.SetActive(true);
        Time.timeScale = 0;
    }

    public void ReturnGame()
    {
        Time.timeScale = 1;
        PausingGameobject_.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
