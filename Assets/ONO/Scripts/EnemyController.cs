using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float Speed;
    public float Angle;
    Vector3 vec;

    void Start()
    {
        float rad = Angle * Mathf.Deg2Rad;
        Vector3 direction = new Vector3(Mathf.Cos(rad), Mathf.Sin(rad), 0);
        vec = direction * Speed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += vec;
    }
}
