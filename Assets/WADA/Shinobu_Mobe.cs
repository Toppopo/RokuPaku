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
    bool stop = false;
    float timer = 0.0f;
    float direct = 1;
    float speed = 2.0f;
    bool hit = false;
    bool PlayerDead;

    void Start()
    {
        playerObject = GameObject.FindWithTag("Player");
    }

    Vector3 velocity = new Vector3(0.01f, 0, 0);

    void Update()
    {
        if(PlayerDead == false)
        {
            PlayerPosi = playerObject.transform.position;
            EnemyPosi = transform.position;

            distance = PlayerPosi.x - EnemyPosi.x;
            dist_abs = Mathf.Abs(distance);

            direct = Mathf.Sign(distance);

            transform.localPosition += velocity * direct * speed;

            if (dist_abs < 1)
            {
                stop = true;
                timer = 1.0f;
            }
        }
        else
        {
            timer -= Time.deltaTime;
            if(timer <= 0.0f)
            {
                stop = false;
            }
        }

        if (hit)
        {
            Destroy(this.gameObject);
        }

        if (Input.GetKey(KeyCode.O))
        {
            PlayerDead = true;
        }

        
    }
}

