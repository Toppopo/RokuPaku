using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSE : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip SE;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Request()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(SE);
    }
}
