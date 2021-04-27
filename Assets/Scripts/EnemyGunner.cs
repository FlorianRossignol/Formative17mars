using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunner : MonoBehaviour
{
    //Handle enemy gunners
    
    [SerializeField] private float range;
    [SerializeField] private Transform target;
    [SerializeField] private GameObject gun;
    [SerializeField] private GameObject enemyBullet;
    [SerializeField] private float fireRate;
    [SerializeField] private float nextTimeToFire = 0;
    [SerializeField] private Transform shoot;
    [SerializeField] private float force;
    bool IsDetected = false;
    private Vector2 Direction;
    
    void Update()
    {
        Vector2 targetPos = target.position;

        Direction = targetPos - (Vector2)transform.position;

        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, Direction, range);

        if (rayInfo)
        {
            if (rayInfo.collider.gameObject.CompareTag("Player"))
            {
                if (IsDetected == false)
                {
                    IsDetected = true;
                }
            }

            else
            {
                if (IsDetected == true)
                {
                    IsDetected = false;
                }
            }
        }

        if (IsDetected == true)
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
