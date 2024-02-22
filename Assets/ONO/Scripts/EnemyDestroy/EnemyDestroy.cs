using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    private float DestroyEnemyTime = 0.2f;
    private int AttackPoint = 0;

   public Vector2 direction = Vector2.right; // �����ړ������i�E�����j
    public float speed = 5.0f; // �ړ����x
    public float duration = 3.0f; // 1��̈ړ��ɗv���鎞��

    private float elapsedTime = 0.0f; // �o�ߎ���
    private Vector3 initialPosition; // �����ʒu
    private bool reverseDirection = false; // �������]�t���O

    private Slash slash;

    void Start()
    {
        slash = GetComponent<Slash>();
        initialPosition = transform.position;
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;

        // �ړ�������؂�ւ��鎞�ԂɂȂ�����
        if (elapsedTime >= duration)
        {
            // �ړ������𔽓]������
            direction = -direction;
            reverseDirection = !reverseDirection;
            elapsedTime = 0.0f; // �o�ߎ��Ԃ����Z�b�g
        }

        // �����ɉ����Ĉړ�
        transform.Translate(-direction * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("��������"+ collision.gameObject.tag);
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
