using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManagerStage4 : MonoBehaviour
{
    //[SerializeField] List<GameObject> Enemis_;
    [SerializeField] private GameObject[] enemy;


    /*void Start()
    {
        EnemisCount_ = 10;
    }
 */
    
    void Update()
    {
        enemy = GameObject.FindGameObjectsWithTag("enemy");

        if (enemy.Length == 0)
        {
            SceneManager.LoadScene("VictoryScene");
        }
    }
    

    /* private void EnemisKilled()
     {
         if(Enemis_ != null)
         {
             EnemisCount_--;
         }
     }*/
}
