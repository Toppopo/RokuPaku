using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    private float DestroyEnemyTime = 0.2f;
    private int AttackPoint = 0;

   public Vector2 direction = Vector2.right; // 初期移動方向（右方向）
    public float speed = 5.0f; // 移動速度
    public float duration = 3.0f; // 1回の移動に要する時間

    private float elapsedTime = 0.0f; // 経過時間
    private Vector3 initialPosition; // 初期位置
    private bool reverseDirection = false; // 方向反転フラグ

    private Slash slash;

    void Start()
    {
        slash = GetComponent<Slash>();
        initialPosition = transform.position;
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;

        // 移動方向を切り替える時間になったら
        if (elapsedTime >= duration)
        {
            // 移動方向を反転させる
            direction = -direction;
            reverseDirection = !reverseDirection;
            elapsedTime = 0.0f; // 経過時間をリセット
        }

        // 方向に応じて移動
        transform.Translate(-direction * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("あたった"+ collision.gameObject.tag);
        if (collision.gameObject.tag == "Attack")
        {
            AttackPoint += 1;
            if (AttackPoint == 2)
            {
                Destroy(this.gameObject, DestroyEnemyTime);
            }
        }
    }
}
