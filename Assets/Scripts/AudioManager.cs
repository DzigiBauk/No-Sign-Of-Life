using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public List<Sounds> sound_clips;

    private void Awake()
    {
        foreach (Sounds s in sound_clips)
        {
            s.source = gameObject.AddComponent<AudioSource>();

            s.source.clip = s.audio;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    public void Play(string name)
    {
        foreach (Sounds s in sound_clips)
        {
            if (s.name == name)
            {
                s.source.Play();
                return;
            }
        }

    }
}
