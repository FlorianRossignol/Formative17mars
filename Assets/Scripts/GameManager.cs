using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
   [SerializeField]  List<GameObject> Enemis_;
    [SerializeField] private GameObject EnemisGameObjects_;

    public int Enemiscount_ = Enemiscount_;

    void Start()
    {
        
    }

    
    void Update()
    {
        if(Enemis_ == 0)
        {
            SceneManager.LoadScene("Stage2");
        }
    }
}
