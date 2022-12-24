using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Button))]
public class PauseButton : MonoBehaviour, IInteractableUI
{
    private LevelPauser _levelPauser;

    public event Action OnPlayerInteracted;

    [Inject]
    public void Construct(LevelPauser levelPauser)
    {
        _levelPauser = levelPauser;
    }

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(Pause);
    }

    private void Pause()
    {
        OnPlayerInteracted?.Invoke();
        _levelPauser.Pause();
    }
}
