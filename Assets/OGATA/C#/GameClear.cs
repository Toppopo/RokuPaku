using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameClear : MonoBehaviour
{

    public float speed = 1.0f;
    private Text text;
    private float time;
    bool enterPushed = false;
    bool start = true;
    public Image fadePanel;
    float time2 = 0.0f;
    float time3 = 0.0f;
    [SerializeField]
    GameObject startSE;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (start == true)
        {
            Color cc = fadePanel.color;
            cc.a -= Time.deltaTime * 2;
            fadePanel.color = cc;
            if (enterPushed == true)
            {
                start = false;
            }
            if (cc.a <= -2.0f)
            {
                start = false;
            }
        }
        if (enterPushed == false)
        {
            if (Input.GetKey(KeyCode.Return))
            {
                enterPushed = true;
                startSE.GetComponent<StartSE>().Request();

            }
        }
        if (enterPushed == true)
        {
            speed = 3.0f;
            time2 += Time.deltaTime;
        }
        if (time2 >= 0.1f)
        {
            Color c = fadePanel.color;
            c.a += Time.deltaTime * 2;
            fadePanel.color = c;
            if (c.a >= 2.0f)
            {
                enterPushed = false;
                time2 = 0;
                Application.LoadLevel("Title");
            }
        }
    }


}
