using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Camera mainCamera;
    private Vector3 OriginalCameraPosition;
    private float BulletForce_ = 20.0f;
    
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
       GameObject PlayerBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
       Rigidbody2D PlayerBody_ = PlayerBullet.GetComponent<Rigidbody2D>();
        PlayerBody_.AddForce(firePoint.up * BulletForce_, ForceMode2D.Impulse);
    }

}
