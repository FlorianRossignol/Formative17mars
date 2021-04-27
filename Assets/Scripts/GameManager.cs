using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    
    [SerializeField] private GameObject[] enemy;
    [SerializeField] private GameObject PausingGameobject_;
    
    
    void Update()
    {
        enemy = GameObject.FindGameObjectsWithTag("enemy");

        if (enemy.Length == 0)
        {
            SceneManager.LoadScene("Stage2");
        }

        if(Input.GetKey(KeyCode.Escape))
        {
            StartingPausingMenu();
        }
    }
    
    private void StartingPausingMenu()
    {
        PausingGameobject_.SetActive(true);
        Time.timeScale = 0;
        Cursor.visible = true;
    }
 
    public void ReturnGame() 
    {
        Time.timeScale = 1;
        PausingGameobject_.SetActive(false);
        Cursor.visible = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
