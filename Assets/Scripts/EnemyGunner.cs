using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunner : MonoBehaviour
{
    [SerializeField] private float range;
    
    [SerializeField] private Transform target;

    bool isDetected = false;

    private Vector2 Direction;

    [SerializeField] private GameObject gun;

    [SerializeField] private GameObject enemyBullet;

    [SerializeField] private float fireRate;

    [SerializeField] private float nextTimeToFire = 0;
    [SerializeField] private Transform shoot;
    [SerializeField] private float force;
    
    void Update()
    {
        Vector2 targetPos = target.position;

        Direction = targetPos - (Vector2)transform.position;

        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, Direction, range);

        if (rayInfo)
        {
            if (rayInfo.collider.gameObject.CompareTag("Player"))
            {
                if (isDetected == false)
                {
                    isDetected = true;
                }
            }

            else
            {
                if (isDetected == true)
                {
                    isDetected = false;
                }
            }
        }

        if (isDetected == true)
        {
            gun.transform.up = Direction;
            if (Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1 / fireRate;
                fire();
            }
        }
    }

    void fire()
    {
        GameObject bulletInst = Instantiate(enemyBullet, shoot.position, shoot.rotation);
        bulletInst.GetComponent<Rigidbody2D>().AddForce(Direction * force);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("bullet"))
        {
            Destroy(gameObject);
        }
    }
}
