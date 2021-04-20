using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField] private SpriteRenderer PlayerSprite_;
    [SerializeField] private Rigidbody2D PlayerBody_;
    private const float MoveSpeed_ = 5.0f;
    //private bool FacingRight_ = false;
    private Vector2 movement_;
    [SerializeField] private Camera cam_;
    private Vector2 MousePos_;
    [SerializeField] private SceneManager currentScene;
    
    void Start()
    {
        PlayerBody_ = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movement_.x = Input.GetAxisRaw("Horizontal");
        movement_.y = Input.GetAxisRaw("Vertical");

       MousePos_ = cam_.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        PlayerBody_.MovePosition(PlayerBody_.position + movement_ * MoveSpeed_ * Time.fixedDeltaTime);

        Vector2 LookDir = MousePos_ - PlayerBody_.position;
        float Angle_ = Mathf.Atan2(LookDir.y, LookDir.x) * Mathf.Rad2Deg - 90f;

        PlayerBody_.rotation = Angle_;
    }
    private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("enemy"))
            {
#pragma warning disable 618
                Application.LoadLevel(Application.loadedLevel);
#pragma warning restore 618
            }
        }
}
