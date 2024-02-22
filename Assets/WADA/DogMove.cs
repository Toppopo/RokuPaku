using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMove : MonoBehaviour
{

    float speed = 2.0f;
    GameObject playerObject;
    Vector3 PlayerPosi;
    Vector3 EnemyPosi;
    float distance;
    float dist_abs;
    bool hit = false;

    void Start()
    {
        playerObject = GameObject.FindWithTag("Player");
    }

    Vector3 velocity = new Vector3(0.01f, 0, 0);

    void Update()
    {

        PlayerPosi = playerObject.transform.position;
        EnemyPosi = transform.position;

        distance = PlayerPosi.x - EnemyPosi.x;
        dist_abs = Mathf.Abs(distance);

        transform.localPosition -= velocity * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "wall")
        {
            velocity.x *= -1.0f;
        }
    }
}
