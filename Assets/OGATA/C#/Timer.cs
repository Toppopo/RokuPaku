using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour
{
    float countTime = 0;//�^�C�}�[�̕b��
    bool start = true;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (start == true)
        {        
         countTime += Time.deltaTime; 
        }
       GetComponent<Text>().text = countTime.ToString("F2");

    }



}
        
