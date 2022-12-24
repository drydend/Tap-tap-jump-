using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Button))]
public class UnpauseButton : MonoBehaviour, IInteractableUI
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
        GetComponent<Button>().onClick.AddListener(UnPause);
    }

    private void UnPause()
    {
        OnPlayerInteracted?.Invoke();
        _levelPauser.UnPause();
    }
}
