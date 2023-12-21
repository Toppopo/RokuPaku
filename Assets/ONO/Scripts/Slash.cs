using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash: MonoBehaviour
{
    [SerializeField]  float MoveSpeed;

    public float deleteTime = 2.0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(MoveSpeed * 0.1f, 0, 0);
        Destroy(gameObject, deleteTime);
        
    }
}
