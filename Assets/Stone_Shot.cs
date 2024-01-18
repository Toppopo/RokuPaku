using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone_shot : MonoBehaviour
{
    [SerializeField] float moveSpeed = 750;                       //移動速度
    [SerializeField] Vector3 moveVec = new Vector3(-1, 0, 0);    //移動方向
    private float breaktime = 0.0f;//崩壊タイマー
    GameObject playerObject;
    Vector3 PlayerPosi;
    Vector3 EnemyPosi;
    float distance;
    float dist_abs;
    bool hit = false;

    private void Start()
    {
        playerObject = GameObject.FindWithTag("Player");

    }
    void Update()
    {

        PlayerPosi = playerObject.transform.position;
        EnemyPosi = transform.position;

        distance = PlayerPosi.x - EnemyPosi.x;
        dist_abs = Mathf.Abs(distance);

        float add_move = moveSpeed * Time.deltaTime;
        transform.Translate(moveVec * add_move * 3);

        breaktime += Time.deltaTime;

        if(dist_abs < 1)
        {
            hit = true;
        }

        if(breaktime > 5.0f || hit == true)
        {
            Destroy(this.gameObject);
        }
    } 
}

