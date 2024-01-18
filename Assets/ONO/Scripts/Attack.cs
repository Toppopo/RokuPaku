using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float fMoveSpeed = 7.0f;
    
    public GameObject katanaObj;

    Vector3 katanaPoint;

    private float second = 0.0f;

    void Start()
    {
        
    }

    void Update()
    {
        second += Time.deltaTime;
        if (second >= 0.3f)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                katanaPoint = transform.Find("KatanaPoint").localPosition;
                Instantiate(katanaObj, transform.position + katanaPoint, Quaternion.identity);
                second = 0.0f;
            }
            Destroy(katanaObj, 0.2f);
        }
    }
}
