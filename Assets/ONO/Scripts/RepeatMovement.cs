using UnityEngine;

public class RepeatMovement : MonoBehaviour
{
    public Transform startPoint;    // �ړ��̊J�n�_
    public Transform endPoint;      // �ړ��̏I���_
    public float speed = 1.0f;      // �ړ����x

    private Vector3 direction;      // �ړ�����

    void Start()
    {
        // �J�n�_����I���_�ւ̕������v�Z
        direction = (endPoint.position - startPoint.position).normalized;
    }

    void Update()
    {
        // ��葬�x�ňړ�
        transform.Translate(direction * speed * Time.deltaTime);

        // �I���_�ɓ��B������A�������t�ɂ���i�J�n�_�Ɍ������Ĉړ��j
        if (Vector3.Distance(transform.position, endPoint.position) < 0.1f)
        {
            direction = (startPoint.position - endPoint.position).normalized;
        }

        // �J�n�_�ɓ��B������A�������t�ɂ���i�I���_�Ɍ������Ĉړ��j
        if (Vector3.Distance(transform.position, startPoint.position) < 0.1f)
        {
            direction = (endPoint.position - startPoint.position).normalized;
        }
    }
}

