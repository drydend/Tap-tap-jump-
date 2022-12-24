using UnityEngine;
using Zenject;

public class AudioPlayersBootstrap : MonoBehaviour
{
    [SerializeField]
    private BackgroundMusicPlayer _backgroundMusicPlayerPrefab;
    [SerializeField]
    private SoundsPlayer _soundsPlayerPrefab;

    [SerializeField]
    private BackgroundMusicList _musicList;

    private Settings _settings;

    [Inject]
    private void Construct(Settings settings)
    {
        _settings = settings;
    }

    private void Awake()
    {
        var audioListener = new GameObject().AddComponent<AudioListener>();
        audioListener.name = "Audio Listener";

        var backgroundMusicPlayer = Instantiate(_backgroundMusicPlayerPrefab);
        backgroundMusicPlayer.Initialize(_settings);
        backgroundMusicPlayer.SetMusicList(_musicList);
        
        var soundsPlayer = Instantiate(_soundsPlayerPrefab);
        soundsPlayer.Initialize(_settings);

        DontDestroyOnLoad(audioListener);
        DontDestroyOnLoad(backgroundMusicPlayer);
        DontDestroyOnLoad(soundsPlayer);
    }
}
