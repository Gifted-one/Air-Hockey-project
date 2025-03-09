using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    public AudioSource Sound;
    public AudioClip SoundClip;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Sound.clip = SoundClip;
        Sound.Play();
    }
}
