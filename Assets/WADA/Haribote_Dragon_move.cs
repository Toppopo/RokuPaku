using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Haribote_Dragon_Move : MonoBehaviour
{

    private float timer = 0.0f;
    private float turntime = 5.0f;
    bool PlayerDead = false;

    Vector3 velocity = new Vector3(-0.01f, 0, 0);

    void Update()
    {
        if(PlayerDead == false)
        {
            transform.localPosition += velocity;
            timer += Time.deltaTime;
            
            if (timer > turntime)
            {
                velocity.x *= -1.0f;
                Vector3 sc = transform.localScale;
                sc.y *= -1;
                transform.localScale = sc;
                timer = 0.0f;
            }
        }

        if (Input.GetKey(KeyCode.O))
        {
            PlayerDead = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        if(other.gameObject.tag != "ground")
        {
            velocity.x *= -1;
        }
    }

}