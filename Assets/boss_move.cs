using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class boss_move : MonoBehaviour
{
    GameObject PlayerObject;
    Vector3 PlPosi;
    Vector3 EnePosi;
    Transform rangeA;
    Transform rangeB;
    Rigidbody rb;

    float gravity = 20;
    float up = 15;
    float RockfallPosi = 15;
    float Plx;
    float MyY;
    float NowMyY = 0;
    float ePosi;
    float direct = 1;
    float speed = 15.0f;//�s�����x
    int HP = 10;        //HP
    int halfHP;         //�{�胂�[�h�̔�������
    float dist;         //�������猩���v���C���[�̈ʒu
    int angry = 1;      //0�Ȃ畁�ʁA�P�Ȃ甭���B
    int ATKnum;         //�U���p�^�[��
    int num1;           //Attack�֐��Ŏg�p
    float ATKtimer = 0.0f;     //�U���܂ł̎���
    bool BossDead = false;
    bool PlayerDead = false;
    bool count1 = false;
    bool count2 = false;
    bool MyDead = false;
    bool Next = false;
    MeshRenderer mesh;
    float timer = 0.0f;

    [SerializeField]GameObject Rock;
    [SerializeField]GameObject Slash;
    [SerializeField]GameObject Break;
    [SerializeField]GameObject Rock2;


void Start()
    {
        PlayerObject = GameObject.FindWithTag("Player");
        halfHP = HP / 2;
        mesh = GetComponent<MeshRenderer>();
        gravity = 200;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {   
        if(!BossDead && !PlayerDead)
        {
            PlPosi = PlayerObject.transform.position;
            EnePosi = transform.position;
            dist = EnePosi.x - PlPosi.x;
              

            Transform myTransform = this.transform;
            float pos = myTransform.position.y;

            if(ATKtimer < 5.0f)
            {
                ATKtimer += Time.deltaTime;
            }

            else
            {
                ATKnum = Attack();

                if (ATKnum == 1)
                {
                    Debug.Log("���[�v�I");
                    transform.position += new Vector3(5 * direct, 0, 0);
                    transform.Rotate(new Vector3(0, 180, 0));
                    direct *= -1; 
                }

                if(ATKnum == 2)
                {
                    while (!Next)
                    {
                        Debug.Log("�Ⓤ��");
                        _ = Instantiate(Rock, EnePosi, Quaternion.identity);
                        timer = 0.0f;
                        Next = true;
                    }
                }

                if(ATKnum == 3 && !Next)
                {
                    Debug.Log("�a��");
                    while (!Next)
                    {
                        _ = Instantiate(Slash, EnePosi, Quaternion.identity);
                        Next = true;
                    }
                }

                if(ATKnum == 4 && !Next)
                {
                    Debug.Log("�n�Ȃ炵");
                    while (!Next)
                    {
                        timer += Time.deltaTime;

                        transform.position += new Vector3(0, 10f, 0);
                        transform.position -= new Vector3(0, 10f, 0);

                        if (timer > 1.0f)
                        {
                            Instantiate(Rock2, new Vector3(RockfallPosi + 10, -7, 0), Rock2.transform.rotation);
                            Instantiate(Rock2, new Vector3(RockfallPosi + 5, -7, 0), Rock2.transform.rotation);
                            Instantiate(Rock2, new Vector3(RockfallPosi, -7, 0), Rock2.transform.rotation);
                            Instantiate(Rock2, new Vector3(RockfallPosi - 5, -7, 0), Rock2.transform.rotation);
                            Instantiate(Rock2, new Vector3(RockfallPosi - 10, -7, 0), Rock2.transform.rotation);
                            timer = 0.0f;
                            Next = true;
                        }
                    }
                }
            ATKtimer = 0.0f;
            ATKnum = 0;
                Next = false;
            }
        }

        if (Input.GetKey(KeyCode.I) || HP < 1)
        {
            BossDead = true;
        }

        if (Input.GetKey(KeyCode.O))
        {
            PlayerDead = true;
        }

        if (BossDead)
        {
            if (!count1)
            {
                count1 = true;
                GameObject newObject = Instantiate(Break, EnePosi, Quaternion.identity);
                mesh = GetComponent<MeshRenderer>();
                Coroutine coroutine = StartCoroutine("Transparent");
            }
        }
    }

    private int Attack()
    {
        if(angry == 1)
        {
            num1 = Random.Range(1, 5);
        }
        else
        {
            num1 = Random.Range(1, 3);
        }

        return num1;
    }

    private IEnumerator Transparent()
    {
        for (int i = 0; i < 255; i++)
        {
            mesh.material.color = mesh.material.color - new Color32(0, 0, 0, 1);
            yield return new WaitForSeconds(0.01f);
        }
    }
}