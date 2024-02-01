using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash2 : MonoBehaviour
{
    public float MoveSpeed = 20.0f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(MoveSpeed * Time.deltaTime,0,0);    
    }
}
