using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMove : MonoBehaviour
{

    [SerializeField]float speed = 1;
    GameObject playerObject;
    Vector3 PlayerPosi;
    Vector3 EnemyPosi;
    float distance;
    float dist_abs;
    bool PlayerDead = false;

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

            transform.localPosition -= velocity * speed;
        }

        if (Input.GetKey(KeyCode.O))
        {
            PlayerDead = true;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag != "ground")
        {
            velocity.x *= -1;
        }
    }
}
