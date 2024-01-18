using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shinobu_Move : MonoBehaviour
{
    GameObject playerObject;
    Vector3 PlayerPosi;
    Vector3 EnemyPosi;
    float distance;
    float dist_abs;
    bool freeze;
    float timer = 0.0f;
    float direct = 1;
    float speed = 2.0f;
    bool hit = false;

    void Start()
    {
        playerObject = GameObject.FindWithTag("Player");
    }

    Vector3 velocity = new Vector3(0.01f, 0, 0);

    void Update()
    {
        if(freeze == false)
        {
            PlayerPosi = playerObject.transform.position;
            EnemyPosi = transform.position;

            distance = PlayerPosi.x - EnemyPosi.x;
            dist_abs = Mathf.Abs(distance);

            direct = Mathf.Sign(distance);

            transform.localPosition += velocity * direct * speed;

            if (dist_abs < 3)
            {
                freeze = true;
                timer = 1.0f;
            }
        }
        else
        {
            timer -= Time.deltaTime;
            if(timer <= 0.0f)
            {
                freeze = false;
            }
        }

        if (hit)
        {
            Destroy(this.gameObject);
        }
    }
}

