using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
   [SerializeField] List<GameObject> Enemis_;
   [SerializeField] private float EnemisCount_ = 10;

    void Start()
    {
        EnemisCount_ = 10;
    }

    
    void Update()
    {
        if(EnemisCount_ == 0)
        {
            SceneManager.LoadScene("Stage2");
        }
    }

    private void EnemisKilled()
    {
        if(Enemis_ != null)
        {
            EnemisCount_--;
        }
    }
}
