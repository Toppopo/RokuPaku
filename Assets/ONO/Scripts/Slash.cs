using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : MonoBehaviour
{
    public float fMoveSpeed = 7.0f;
    
    public GameObject katanaObj;
    public GameObject BallObj;
    public GameObject BakuObj;
    private GameObject InstantiatedKatana;
    private GameObject InstantiatedBall;
    private GameObject InstantiatedBaku1;
    private GameObject InstantiatedBaku2;
    private GameObject InstantiatedBaku3;
    private GameObject InstantiatedBaku4;

    Vector3 katanaPoint;
    Vector3 ballPoint;
    Vector3 bakuPoint1;
    Vector3 bakuPoint2;
    Vector3 bakuPoint3;
    Vector3 bakuPoint4;

    private float second = 0.0f;
    private float InTime = 0.0f;
    private float DestroyTime = 1f;
    private float DestroyTime2 = 2f;
    private float DestroyTime3 = 1f;

    private Animator anima;

    public enum AttackMode
    {
        Normal,
        SpecialAttack1,
        SpecialAttack2
    }

    private AttackMode currentAttackMode;

    void Start()
    {
        currentAttackMode = AttackMode.Normal;

        katanaPoint = transform.Find("KatanaPoint").localPosition;
        ballPoint = transform.Find("BallPoint").localPosition;
        bakuPoint1 = transform.Find("BakuPoint1").localPosition;
        bakuPoint2 = transform.Find("BakuPoint2").localPosition;
        bakuPoint3 = transform.Find("BakuPoint3").localPosition;
        bakuPoint4 = transform.Find("BakuPoint4").localPosition;

        anima = GetComponent<Animator>();
    }

    void Update()
    {

        Vector2 objectForward = transform.forward;

        second += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SwitchAttackMode();
        }

        // ここで攻撃モードに基づいた処理を実行
        PerformAttack();

    }
    void SwitchAttackMode()
    {
        // 攻撃モードを順番に切り替える（ループする）
        currentAttackMode = (AttackMode)(((int)currentAttackMode + 1) % 3);
        Debug.Log("Attack Mode switched to: " + currentAttackMode);
    }

    void PerformAttack()
    {
        // 攻撃モードに基づいて異なる攻撃処理を実行
        switch (currentAttackMode)
        {
            case AttackMode.Normal:
                if (second >= 1f)
                {
                    InTime += Time.deltaTime;
                    if (Input.GetKeyDown(KeyCode.K) && InTime >= 1f)
                    {
                        InstantiatedKatana =Instantiate(katanaObj, transform.position + katanaPoint,Quaternion.identity);
                        second = 0.0f;
                        anima.SetBool("slash", true);
                        Destroy(InstantiatedKatana, DestroyTime);
                    }
                    else
                    {
                        anima.SetBool("slash", false);
                    }
                }
                Debug.Log("Performing Normal Attack");
                break;

            case AttackMode.SpecialAttack1:
                if (second >= 1.5f)
                {
                    InTime += Time.deltaTime;
                    if (Input.GetKeyDown(KeyCode.J) && InTime >= 1f)
                    {
                        InstantiatedBall = Instantiate(BallObj, transform.position + ballPoint, Quaternion.identity);
                        second = 0.0f;
                        anima.SetBool("slash", true);
                        Destroy(InstantiatedBall, DestroyTime2);
                    }
                    else
                    {
                        anima.SetBool("slash", false);
                    }
                }
                Debug.Log("Performing Special Attack 1");
                break;

            case AttackMode.SpecialAttack2:
                if (second >= 4f)
                {
                    InTime += Time.deltaTime;
                    if (Input.GetKeyDown(KeyCode.L) && InTime >= 1f)
                    {
                        InstantiatedBaku1 = Instantiate(BakuObj, transform.position + bakuPoint1, Quaternion.identity);
                        InstantiatedBaku2 = Instantiate(BakuObj, transform.position + bakuPoint2, Quaternion.identity);
                        InstantiatedBaku3 = Instantiate(BakuObj, transform.position + bakuPoint3, Quaternion.identity);
                        InstantiatedBaku4 = Instantiate(BakuObj, transform.position + bakuPoint4, Quaternion.identity);
                        second = 0.0f;
                        anima.SetBool("slash", true);
                        Destroy(InstantiatedBaku1, DestroyTime3);
                        Destroy(InstantiatedBaku2, DestroyTime3);
                        Destroy(InstantiatedBaku3, DestroyTime3);
                        Destroy(InstantiatedBaku4, DestroyTime3);
                    }
                    else
                    {
                        anima.SetBool("slash", false);
                    }
                }
                Debug.Log("Performing Special Attack 2");
                break;

            default:
                // 予期せぬ攻撃モードの場合は通常攻撃を実行
                Debug.LogWarning("Unknown Attack Mode. Performing Normal Attack");
                break;
        }
    }
}
