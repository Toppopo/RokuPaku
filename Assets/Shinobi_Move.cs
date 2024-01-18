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
    [SerializeField]GameObject Shinobu;

    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.FindWithTag("Player");

        PlayerPosi = playerObject.transform.position;
        EnemyPosi = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPosi = playerObject.transform.position;
        EnemyPosi = transform.position;

        distance = PlayerPosi.x - EnemyPosi.x;
        dist_abs = Mathf.Abs(distance);

        if(dist_abs < 36)
        {
            GameObject newObject = Instantiate(Shinobu, EnemyPosi, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
