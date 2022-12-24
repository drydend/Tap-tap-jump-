using System;

public class Settings
{
    private bool _isMusicOn;
    private bool _isSoundsOn;

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

    public event Action IsMusicOnChanged;
    public event Action IsSoundsOnChanged;

    public Settings(bool isMusicOn, bool isSoundsOn)
    {
        IsMusicOn = isMusicOn;
        IsSoundsOn = isSoundsOn;
    }

    public Settings()
    {
        _isMusicOn = true;
        _isSoundsOn = true;
    }

}