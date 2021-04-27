using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject Enemy_;

    void Start()
    {
       
    }

    
    void Update()
    {
        Enemy_ = GameObject.FindGameObjectsWithTag("Enemy");
        if(Enemy_.length == 0)
        {
            SceneManager.LoadScene("Stage2");
        }
    }
    

   /* private void EnemisKilled()
    {
        if(Enemis_ == null)
        {
            EnemisCount_--;
        }
    }*/
}
