using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touteki_Move : MonoBehaviour
{

    GameObject playerObject;
    [SerializeField] GameObject Stone;
    Vector3 PlayerPosi;
    Vector3 EnemyPosi;
    float distance;
    float dist_abs;
    bool hit = false;
    bool PlayerDead = false;

    void Start()
    {
        playerObject = GameObject.FindWithTag("Player");
    }

    float time = 0.0f;


    void Update()
    {
        if(PlayerDead == false)
        {
            PlayerPosi = playerObject.transform.position;
            EnemyPosi = transform.position;

            distance = PlayerPosi.x - EnemyPosi.x;
            dist_abs = Mathf.Abs(distance);

            time += Time.deltaTime;
            if (time > 5.0f)
            {
                _ = Instantiate(Stone, EnemyPosi, Quaternion.identity);
                time = 0.0f;
            }

            if (hit)
            {
                Destroy(this.gameObject);
            }

            if (Input.GetKey(KeyCode.O))
            {
                PlayerDead = true;
            }

            if (Input.GetKey(KeyCode.O))
            {
                PlayerDead = true;
            }
        }
    }
}