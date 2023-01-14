using System;

[Serializable]
public class Settings
{
    private bool _isMusicOn;
    private bool _isSoundsOn;
    private bool _isControlInverted;
    public bool IsMusicOn
    {
        get
        {
            return _isMusicOn;
        }

        set
        {
            _isMusicOn = value;
            IsMusicOnChanged?.Invoke();
        }
    }

    public bool IsSoundsOn
    {
        get
        {
            return _isSoundsOn;
        }

        set
        {
            _isSoundsOn = value;
            IsSoundsOnChanged?.Invoke();
        }
    }

    public bool IsControlInverted
    {
        get
        {
            return _isMusicOn;
        }

        set
        {
            _isMusicOn = value;
            IsControlInvertedChanged?.Invoke();
        }
    }

    public event Action IsMusicOnChanged;
    public event Action IsSoundsOnChanged;
    public event Action IsControlInvertedChanged;

    public Settings(bool isMusicOn, bool isSoundsOn, bool isControlInverted)
    {
        _isMusicOn = isMusicOn;
        _isSoundsOn = isSoundsOn;
        _isControlInverted = isControlInverted;
    }

    public Settings()
    {
        _isMusicOn = true;
        _isSoundsOn = true;
        _isControlInverted = false;
    }

}