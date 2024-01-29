using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    [SerializeField] public float speed;

    private Rigidbody2D rb = null;
    private Animator animation;

    [SerializeField] float jumpForce = 430f;

    private int jumpCount = 0;

    private bool isMove = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animation = GetComponent<Animator>();
    }

    void Update()
    {
        if (!isMove)
        {
            float xSpeed = 0.0f;

            if (Input.GetKey(KeyCode.D))
            {
                transform.localScale = new Vector3(1, 1, 1);
                xSpeed = speed;
                animation.SetBool("move 1", true);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                transform.localScale = new Vector3(-1, 1, 1);
                xSpeed = -speed;
                animation.SetBool("move 1", true);
            }
            else
            {
                animation.SetBool("move 1", false);
                xSpeed = 0.0f;
            }
            rb.velocity = new Vector2(xSpeed, rb.velocity.y);
            if (Input.GetKeyDown(KeyCode.Space) && this.jumpCount < 1)
            {
                this.rb.AddForce(transform.up * jumpForce);
                jumpCount++;
                isMove = true;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
            isMove = false;
        }
    }
    /*void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Application.LoadLevel("GameOver");
        }
    }*/
}
