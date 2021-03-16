using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField] private SpriteRenderer PlayerSprite_;
    [SerializeField] private Rigidbody2D PlayerBody_;
    private const float MoveSpeed_ = 2.0f;
    private bool FacingRight_ = false;


    void Start()
    {
        
    }

    
    void FixedUpdate()
    {
        PlayerBody_.velocity = new Vector2(Input.GetAxis("Horizontal") * MoveSpeed_, PlayerBody_.velocity.y);
        PlayerBody_.velocity = new Vector2(PlayerBody_.velocity.x, Input.GetAxis("Vertical") * MoveSpeed_);
    }
}
