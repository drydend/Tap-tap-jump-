using System;

public class LevelPauser
{
    public bool IsPaused { get; private set; }

    public event Action OnLevelPaused;
    public event Action OnLevelUnpaused;

    public void Pause()
    {
        if (IsPaused)
        {
            return;
        }

        IsPaused = true;
        OnLevelPaused?.Invoke();
    }

    public void Unpause()
    {
        if (!IsPaused)
        {
            return;
        }

        IsPaused = false;
        OnLevelUnpaused?.Invoke();
    }
}