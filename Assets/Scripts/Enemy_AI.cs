using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Enemy_AI : MonoBehaviour
{
    private Rigidbody2D Rb;
    private PlayerCharacter Player;
    [SerializeField] private float moveSpeed;
    private Vector3 DirectionToPlayer;
    private Vector3 LocalScale;

    private void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        Player = FindObjectOfType(typeof(PlayerCharacter)) as PlayerCharacter;
        LocalScale = transform.localScale;
    }

    private void FixedUpdate()
    {
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        DirectionToPlayer = (Player.transform.position - transform.position).normalized;
        Rb.velocity = new Vector2(DirectionToPlayer.x, DirectionToPlayer.y) * moveSpeed;
    }

    private void LateUpdate()
    {
        if (Rb.velocity.x > 0)
        {
            transform.localScale = new Vector3(LocalScale.x, LocalScale.y, LocalScale.z);
        }
        else if (Rb.velocity.x < 0)
        {
            transform.localScale = new Vector3(-LocalScale.x, LocalScale.y, LocalScale.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("bullet"))
        {
            Destroy(gameObject);
        }
    }
}
