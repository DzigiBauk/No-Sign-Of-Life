using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sounds
{
    public string name;
    public AudioClip audio;

    [Range(0f, 1f)]
    public float volume = 0.4f;

    [Range(0f, 3f)]
    public float pitch = 1;

    [HideInInspector]
    public AudioSource source;
}
