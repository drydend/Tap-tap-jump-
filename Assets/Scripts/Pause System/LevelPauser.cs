using System;
using System.Collections.Generic;
using System.Collections;

public class LevelPauser
{
    private List<IPauseable> _pauseables = new List<IPauseable>();
    private PauseMenuUI _pauseMenu;
    private UIMenuHandler _menuHandler;

    public bool IsPaused { get; private set; }

    public event Action OnLevelPaused;
    public event Action OnLevelUnpaused;

    public LevelPauser(PauseMenuUI pauseMenu, UIMenuHandler menuHandler)
    {
        _pauseMenu = pauseMenu;
        _menuHandler = menuHandler;
    }

    public void Subscribe(IPauseable pauseable)
    {
        _pauseables.Add(pauseable);
    }

    public void UnSubscribe(IPauseable pauseable)
    {
        _pauseables.Remove(pauseable);
    }

    public void Pause()
    {
        if (IsPaused)
        {
            return;
        }


        _menuHandler.OpenMenu(_pauseMenu);

        IsPaused = true;

        foreach (var pauseable in _pauseables)
        {
            pauseable.Pause();
        }

        OnLevelPaused?.Invoke();
    }

    public void UnPause()
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

        yield return _menuHandler.CloseCurrentMenu();

        foreach (var pauseable in _pauseables)
        {
            pauseable.Unpause();
        }

        IsPaused = false;
        OnLevelUnpaused?.Invoke();
    }
}