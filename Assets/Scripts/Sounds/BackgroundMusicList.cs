using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Music list")]
public class BackgroundMusicList : ScriptableObject
{
    [SerializeField]
    private List<AudioClip> _audioClips;
    [Space]
    [SerializeField]
    private int _clipCycle;

    private List<AudioClip> _clipsToPlay;
    private Queue<AudioClip> _playedClips = new Queue<AudioClip>();


    public AudioClip GetRandomClip()
    {
        var index = Random.Range(0, _clipsToPlay.Count);
        var clip = _clipsToPlay[index];

        _clipsToPlay.RemoveAt(index);
        _playedClips.Enqueue(clip);

        if(_clipCycle < _playedClips.Count)
        {
            _clipsToPlay.Add(_playedClips.Dequeue());
        }

        return clip;
    }

    private void OnEnable()
    {
        _clipsToPlay = new List<AudioClip>(_audioClips);
    }
}
