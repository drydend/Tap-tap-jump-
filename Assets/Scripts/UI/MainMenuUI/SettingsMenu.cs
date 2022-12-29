using System.Collections;
using UnityEngine;
using Zenject;

public class SettingsMenu : AnimatedUIMenu
{
    [SerializeField]
    private Toggle _musicToggle;
    [SerializeField]
    private Toggle _soundsToggle;
    [SerializeField]
    private Toggle _inverseOfInputToggle;

    private Settings _settings;

    [Inject]
    public void Construct(Settings settings)
    {
        _settings = settings;

        _musicToggle.OnValueChanged += () => _settings.IsMusicOn = _musicToggle.IsOn;
        _soundsToggle.OnValueChanged += () => _settings.IsSoundsOn = _soundsToggle.IsOn;
        _inverseOfInputToggle.OnValueChanged += () => _settings.IsControlInverted = _inverseOfInputToggle.IsOn;
    }

    public override IEnumerator Open()
    {
        _soundsToggle.SetValue(_settings.IsSoundsOn);
        _musicToggle.SetValue(_settings.IsMusicOn);
        _inverseOfInputToggle.SetValue(_settings.IsControlInverted);

        yield return base.Open();
    }
}
