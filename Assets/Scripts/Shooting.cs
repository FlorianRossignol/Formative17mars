using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Transform FirePoint_;
    [SerializeField] private GameObject BulletPrefab_;
    [SerializeField] private Camera MainCamera;
    private Vector3 originalCameraPosition_; 
    private float ShakeAmt_ = 0;
    private float BulletForce_ = 20.0f;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            
            Shoot();
            FindObjectOfType<AudioManager>().Play("Shoot");
        }
    }

    private void Shoot()
    {
       GameObject PlayerBullet = Instantiate(BulletPrefab_, FirePoint_.position, FirePoint_.rotation);
       Rigidbody2D PlayerBody_ = PlayerBullet.GetComponent<Rigidbody2D>();
        PlayerBody_.AddForce(FirePoint_.up * BulletForce_, ForceMode2D.Impulse);
    }

}
