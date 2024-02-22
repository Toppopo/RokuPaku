using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone_shot : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1;                        //移動速度
    [SerializeField] Vector3 moveVec = new Vector3(-1, 0, 0);    //移動方向
    private float breaktime = 0.0f;//崩壊タイマー
    GameObject playerObject;
    Vector3 PlayerPosi;
    Vector3 EnemyPosi;
    float distance;
    float dist_abs;
    float direct;
    bool PlayerDead = false;

    private void Start()
    {
        playerObject = GameObject.FindWithTag("Player");
        PlayerPosi = playerObject.transform.position;
        EnemyPosi = transform.position;

        distance = EnemyPosi.x - PlayerPosi.x;
        direct = Mathf.Sign(distance);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "wall")
        {
            Debug.Log("hit!!");
            Destroy(this.gameObject);
        }
    }

    void Update()
    {
        if(PlayerDead == false)
        {

            float add_move = moveSpeed * Time.deltaTime;
            transform.Translate(moveVec * add_move * direct);

            breaktime += Time.deltaTime;

            if (breaktime > 5.0f)
            {
                Destroy(this.gameObject);
            }
        }

        if (Input.GetKey(KeyCode.O))
        {
            PlayerDead = true;
        }
    } 
}

