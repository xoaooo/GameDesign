using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [Header("--- Audio Source ---")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;


    [Header("--- Audio Clip ---")]
    public AudioClip damage;
    public AudioClip godMode;
    public AudioClip meat;
    public AudioClip backgroundMusic, titleMusic;
    public AudioClip coin;
    public AudioClip death;
    public AudioClip dash;
    public AudioClip nope;

    private void Start()
    {
        musicSource.clip = backgroundMusic;
        musicSource.Play();
    }
    
    public void PlaySFX(AudioClip audio)
    {
        SFXSource.PlayOneShot(audio);
    }

    public void PlayMusic(AudioClip audio)
    {
        musicSource.clip = audio;
        musicSource.Play();
    }



    

}

