using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class RestartButton : MonoBehaviour, IInteractableUI
{
    [SerializeField]
    private Level _level;

    public event Action OnPlayerInteracted;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(Restart);
    }

    private void Restart()
    {
        OnPlayerInteracted?.Invoke();
        _level.RestartLevel();
    }
}
