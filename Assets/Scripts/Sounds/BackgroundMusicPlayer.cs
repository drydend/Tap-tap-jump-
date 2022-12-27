using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(AudioSource))]
public class BackgroundMusicPlayer : MonoBehaviour
{
    public static BackgroundMusicPlayer Instance { get; private set; }

    [SerializeField]
    private float _fadeDuration;
    [SerializeField]
    private float _unFadeDuration;

    private BackgroundMusicList _musicList;
    private Settings _settings;

    private AudioSource _audioSource;
    private bool _isPaused;

    private Coroutine _fadeCoroutine;

    public void Initialize(Settings settings)
    {
        _settings = settings;
        _settings.IsMusicOnChanged += ChangeState;

        _audioSource = GetComponent<AudioSource>();
        StartCoroutine(PlayRoutine());

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            throw new System.Exception("Sounds player can be only one");
        }
    }

    public void SetMusicList(BackgroundMusicList music)
    {
        _musicList = music;
    }

    private void PlayRandomClip()
    {
        _audioSource.Stop();
        _audioSource.clip = _musicList.GetRandomClip();
        _audioSource.Play();
    }

    private void ChangeState()
    {
        if (_settings.IsMusicOn)
        {
            UnPause();
        }
        else
        {
            Pause();
        }
    }

    private void UnPause()
    {   
        if(_fadeCoroutine != null)
        {
            StopCoroutine(_fadeCoroutine);
        }

        _isPaused = false;
        _fadeCoroutine = StartCoroutine(VolumeUnFadeRoutine());
    }

    private void Pause()
    {
        if (_fadeCoroutine != null)
        {
            StopCoroutine(_fadeCoroutine);
        }

        _isPaused = true;
        _fadeCoroutine = StartCoroutine(VolumeFadeRoutine());
    }

    private IEnumerator PlayRoutine()
    {
        while (true)
        {
            PlayRandomClip();

            while (_audioSource.isPlaying || _isPaused)
            {
                yield return null;
            }
        }
    }

    private IEnumerator VolumeFadeRoutine()
    {
        float timeElapsed = 0f;

        while(_audioSource.volume != 0)
        {
            _audioSource.volume = Mathf.Lerp(_audioSource.volume, 0, timeElapsed);

            timeElapsed += Time.unscaledDeltaTime / _fadeDuration;
            Mathf.Clamp(timeElapsed, 0, 1);
            yield return null;
        }

        _audioSource.Pause();
    }

    private IEnumerator VolumeUnFadeRoutine()
    {
        _audioSource.UnPause();

        float timeElapsed = 0f;

        while (_audioSource.volume != 1)
        {
            _audioSource.volume = Mathf.Lerp(_audioSource.volume, 1, timeElapsed);

            timeElapsed += Time.unscaledDeltaTime / _unFadeDuration;
            Mathf.Clamp(timeElapsed, 0, 1);
            yield return null;
        }
    }
}
