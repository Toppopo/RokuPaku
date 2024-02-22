using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier_Move : MonoBehaviour
{
    private GameObject playerObject;
    private Vector3 PlayerPosi;
    private Vector3 EnemyPosi;
    private float distance;
    private float dist_abs;
    private float speed = 30.0f;
    bool hit = false;
    bool PlayerDead = false;
    [SerializeField] GameObject WFX_ExplosiveSmokeGround;


    void Start()
    {
        playerObject = GameObject.FindWithTag("Player");
    }  

    void Update()
    {
        if(PlayerDead == false)
        {
            PlayerPosi = playerObject.transform.position;
            EnemyPosi = transform.position;

            distance = PlayerPosi.x - EnemyPosi.x;
            dist_abs = Mathf.Abs(distance);

            if (dist_abs < 36)
            {
                Vector3 posi = transform.localPosition;
                posi.x += Mathf.Sign(distance) * speed * Time.deltaTime;
                transform.localPosition = posi;
            }

            if (dist_abs < 1 || hit)
            {
                GameObject newObject = Instantiate(WFX_ExplosiveSmokeGround, EnemyPosi, Quaternion.identity);
                Destroy(this.gameObject);
            }
        }

        if (Input.GetKey(KeyCode.O))
        {
            PlayerDead = true;
        }
    }
}