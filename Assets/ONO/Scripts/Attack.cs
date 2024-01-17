using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    public float Speed = 7.0f;

    public GameObject AttackObj;

    Vector3 attackPoint;

    void Start()
    {
        attackPoint = transform.Find("AttackPoint").localPosition;
        Instantiate(AttackObj, transform.position + attackPoint, Quaternion.identity);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Instantiate(AttackObj);
            
        }   
    }
}
