using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] List<AudioClip> playlist;

    private AudioSource audioSource;
    private AudioClip lastClip;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            lastClip = GetRandomClip();
            audioSource.clip = lastClip;
            audioSource.Play();
        }
    }

    private AudioClip GetRandomClip()
    {
        AudioClip clip = playlist[Random.Range(0, playlist.Count)];
        if (lastClip == clip)
        {
            return GetRandomClip();
        }
        return clip;
    }
}
