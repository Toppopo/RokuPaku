using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shinobi_Move : MonoBehaviour
{
    GameObject playerObject;
    Vector3 PlayerPosi;
    Vector3 EnemyPosi;
    float distance;
    float dist_abs;
    bool PlayerDead = false;
    [SerializeField]GameObject Shinobu;

    void Start()
    {
        playerObject = GameObject.FindWithTag("Player");

        PlayerPosi = playerObject.transform.position;
        EnemyPosi = transform.position;
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
                GameObject newObject = Instantiate(Shinobu, EnemyPosi, Quaternion.identity);
                Destroy(this.gameObject);
            }
        }

        if (Input.GetKey(KeyCode.O))
        {
            PlayerDead = true;
        }
    }
}
