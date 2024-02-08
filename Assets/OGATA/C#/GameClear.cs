using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClear : MonoBehaviour
{
    bool enterPushed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enterPushed == false)
        {
            if (Input.GetKey(KeyCode.Return))
             {
                enterPushed = true;
             }
                if(enterPushed == true)
                {
                Application.LoadLevel("Title");
                }

        }
    }
}
