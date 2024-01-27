using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float fMoveSpeed = 7.0f;
    
    public GameObject katanaObj;

    float Destroy = 1.0f;

    Vector3 katanaPoint;

    private float second = 0.0f;

    void Start()
    {
        katanaPoint = transform.Find("KatanaPoint").localPosition;
    }

    void Update()
    {
        second += Time.deltaTime;
        if (second >= 0.45f)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                Instantiate(katanaObj, transform.position + katanaPoint, Quaternion.identity);
                second = 0.0f;
            }
        }
        DestroyObject(katanaObj,Destroy);
    }
}
