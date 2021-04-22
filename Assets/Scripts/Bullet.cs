using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject HitEffect_;
   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect_ = Instantiate(HitEffect_, transform.position, Quaternion.identity);
        Destroy(effect_, 0.2f);
        Destroy(gameObject);
        FindObjectOfType<AudioManager>().Play("Boom");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject effect_ = Instantiate(HitEffect_, transform.position, Quaternion.identity);
        Destroy(effect_, 0.2f);
        Destroy(gameObject);
        FindObjectOfType<AudioManager>().Play("Boom");
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
