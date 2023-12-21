using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float speed = 40.0f;

    public GameObject AttackObj;


    Vector3 AttackS;

    private void Start()
    {
        AttackS = transform.Find("AttackS").localPosition;
        Instantiate(AttackObj, transform.position + AttackS, Quaternion.identity);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Instantiate(AttackObj, transform.position + AttackS, Quaternion.identity);
            
        }
    }
}
