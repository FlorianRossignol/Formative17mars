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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ShakeAmt_ = collision.relativeVelocity.magnitude * .0025f;
        InvokeRepeating("CameraShake", 0, .01f);
        Invoke("StopShaking", 0.3f);
    }

    private void CameraShake()
    {
        if(ShakeAmt_>0)
        {
            float quakeAmt = Random.value * ShakeAmt_ * 2 - ShakeAmt_;
            Vector3 pp = MainCamera.transform.position;
            MainCamera.transform.position = pp;
        }
    }

    private void StopShaking()
    {
        CancelInvoke("CameraShake");
        MainCamera.transform.position = originalCameraPosition_;
    }
}
