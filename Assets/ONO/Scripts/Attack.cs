using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float fMoveSpeed = 7.0f;
    
    public GameObject katanaObj;

    Vector3 katanaPoint;

    private float second = 0.0f;
    private float InTime = 0.0f;

    private Animator anima;

    void Start()
    {
        katanaPoint = transform.Find("KatanaPoint").localPosition;

        anima = GetComponent<Animator>();
    }

    void Update()
    {
        second += Time.deltaTime;
        if (second >= 0.45f)
        {
            InTime += Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.K) && InTime >= 0.5f)
            {
                Instantiate(katanaObj, transform.position + katanaPoint,Quaternion.identity);
                second = 0.0f;
                anima.SetBool("slash", true);
            }
            else
            {
                anima.SetBool("slash", false);
            }
        }
    }
}
