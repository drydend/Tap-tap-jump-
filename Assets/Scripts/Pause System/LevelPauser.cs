using System;

public class LevelPauser
{
    public event Action OnLevelPaused;
    public event Action OnLevelUnpaused;

    public void Pause()
    {
        OnLevelPaused?.Invoke();
    }

    public void Unpause()
    {
        OnLevelUnpaused?.Invoke();
    }
}