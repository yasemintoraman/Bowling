using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : MonoBehaviour

    
{
    private Ball ball;
    AudioSource sound;

    private void Start()
    {
        ball = GameObject.FindWithTag("Ball").GetComponent<Ball>();
        sound = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        sound.Play();
     
    }
}
