using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Serialization;

public class turret : MonoBehaviour
{
    public float range;

    public Transform target;

    bool IsDetected = false;

    private Vector2 Direction;

    [SerializeField] private GameObject gun;

    [SerializeField] private GameObject enemyBullet;

    public float fireRate;

    [SerializeField] private float nextTimeToFire = 0;
    [SerializeField] private Transform shoot;
    public float force;
    
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
}
