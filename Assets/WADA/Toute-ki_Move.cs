using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touteki_Move : MonoBehaviour
{

    GameObject playerObject;
    GameObject stone;
    Vector3 PlayerPosi;
    Vector3 EnemyPosi;
    float distance;
    float dist_abs;
    bool hit = false;

    void Start()
    {
        playerObject = GameObject.FindWithTag("Player");
    }

    float time = 0.0f;


    void Update()
    {
        PlayerPosi = playerObject.transform.position;
        EnemyPosi = transform.position;

        distance = PlayerPosi.x - EnemyPosi.x;
        dist_abs = Mathf.Abs(distance);

        time += Time.deltaTime;
        if(time > 5.0f)
        {
            GameObject newObject = Instantiate(stone, EnemyPosi, Quaternion.identity);
            time = 0.0f;
        }

        if (hit)
        {
            Destroy(this.gameObject);
        }
    }
}