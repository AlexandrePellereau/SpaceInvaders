using System;
using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public String name;
    
    public AudioClip clip;
    
    [Range(0f, 1f)]
    public float volume = 0.5f;
    [Range(0.1f, 3f)]
    public float pitch = 1;
    
    public bool loop;
    
    [HideInInspector]
    public AudioSource source;
}
