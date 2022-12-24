using System;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(AudioSource))]
public class SoundsPlayer : MonoBehaviour
{
    public static SoundsPlayer Instance { get; private set; }

    private AudioSource _audioSource;
    private Settings _settings;

    public void Initialize(Settings settings)
    {
        _settings = settings;

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            throw new System.Exception("Sounds player can be only one");
        }
    }

    public void Play(AudioClip audioClip)
    {
        if (_settings.IsSoundsOn)
        {
            _audioSource.PlayOneShot(audioClip);
        }
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>(); _audioSource = GetComponent<AudioSource>();
    }
}
