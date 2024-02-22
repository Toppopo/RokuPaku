using UnityEngine;

public class RepeatMovement : MonoBehaviour
{
    public Transform startPoint;    // 移動の開始点
    public Transform endPoint;      // 移動の終了点
    public float speed = 1.0f;      // 移動速度

    private Vector3 direction;      // 移動方向

    void Start()
    {
        // 開始点から終了点への方向を計算
        direction = (endPoint.position - startPoint.position).normalized;
    }

    void Update()
    {
        // 一定速度で移動
        transform.Translate(direction * speed * Time.deltaTime);

        // 終了点に到達したら、方向を逆にする（開始点に向かって移動）
        if (Vector3.Distance(transform.position, endPoint.position) < 0.1f)
        {
            direction = (startPoint.position - endPoint.position).normalized;
        }

        // 開始点に到達したら、方向を逆にする（終了点に向かって移動）
        if (Vector3.Distance(transform.position, startPoint.position) < 0.1f)
        {
            direction = (endPoint.position - startPoint.position).normalized;
        }
    }
}

