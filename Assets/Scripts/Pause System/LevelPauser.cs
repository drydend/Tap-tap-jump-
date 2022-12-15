using System;
using System.Collections.Generic;
using System.Collections;

public class LevelPauser
{
    private List<IPauseable> _pauseables = new List<IPauseable>();
    private PauseMenuUI _pauseMenu;

    public bool IsPaused { get; private set; }

    public event Action OnLevelPaused;
    public event Action OnLevelUnpaused;

    public LevelPauser(PauseMenuUI pauseMenu)
    {
        _pauseMenu = pauseMenu;
    }

    public void Subscribe(IPauseable pauseable)
    {
        _pauseables.Add(pauseable);
    }

    public void Unsubscribe(IPauseable pauseable)
    {
        _pauseables.Remove(pauseable);
    }

    public void Pause()
    {
        if (IsPaused)
        {
            return;
        }


        _pauseMenu.Open();

        IsPaused = true;

        foreach (var pauseable in _pauseables)
        {
            pauseable.Pause();
        }

        OnLevelPaused?.Invoke();
    }

    public void Unpause()
    {
        if (!IsPaused)
        {
            return;
        }

        Coroutines.StartRoutine(UnpauseRoutine());
    }

    public IEnumerator UnpauseRoutine()
    {
        if (!IsPaused)
        {
            yield break;
        }

        yield return _pauseMenu.Close();

        foreach (var pauseable in _pauseables)
        {
            pauseable.Unpause();
        }

        IsPaused = false;
        OnLevelUnpaused?.Invoke();
    }
}