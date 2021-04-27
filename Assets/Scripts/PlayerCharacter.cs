using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class PlayerCharacter : MonoBehaviour
{
    //Player character script
    
    [SerializeField] private SpriteRenderer playerSprite;
    [SerializeField] private Rigidbody2D playerBody;
    private const float MoveSpeed = 5.0f;
    private Vector2 Movement;
    [SerializeField] private Camera cam;
    private Vector2 MousePos;

    void Start()
    {
        Cursor.visible = false;
        playerBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Movement.x = Input.GetAxisRaw("Horizontal");
        Movement.y = Input.GetAxisRaw("Vertical");

       MousePos = cam.ScreenToWorldPoint(Input.mousePosition);
       if (Input.GetKey(KeyCode.R))
       {
           SceneManager.LoadScene(Application.loadedLevel);
       }
    }

    void FixedUpdate()
    {
        playerBody.MovePosition(playerBody.position + Movement * MoveSpeed * Time.fixedDeltaTime);

        Vector2 LookDir = MousePos - playerBody.position;
        float Angle_ = Mathf.Atan2(LookDir.y, LookDir.x) * Mathf.Rad2Deg - 90f;

        playerBody.rotation = Angle_;
    }
    private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("enemy"))
            {
#pragma warning disable 618
                SceneManager.LoadScene(Application.loadedLevel);
#pragma warning restore 618
            }
        }
}
