using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    private float DestroyEnemyTime = 0.2f;
    private int AttackPoint = 0;

    private Slash slash;

    void Start()
    {
        slash = GetComponent<Slash>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("‚ ‚½‚Á‚½"+ collision.gameObject.tag);
        if (collision.gameObject.tag == "Attack")
        {
            AttackPoint += 1;
            if (AttackPoint == 2)
            {
                Destroy(this.gameObject, DestroyEnemyTime);
            }
        }
    }
}
