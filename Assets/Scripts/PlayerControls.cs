using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private Rigidbody2D rb;
    GameObject player;
    float moveSpeed = 10f;
    float jumpHeight = 10f;
    bool isGrounded;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, rb.velocity.y);
    }

    void Jump()
    {
        rb.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isGrounded = false;
            Jump();
        }

        if (collision.collider.tag == "Deadzone")
            gameObject.SetActive(false);
    }
}
